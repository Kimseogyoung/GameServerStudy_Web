using Scriban;
using Scriban.Runtime;
using System.Security.Cryptography;

namespace ClassGenerator
{
    class Generator
    {
        public static void Main(string[] args)
        {
            // 기본 값 설정
            string argInputPath = "";
            string argOutputPath = "";

            var projectPath = GetProjPath();

            // 명령줄 인수 처리
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--inputPath" && i + 1 < args.Length)
                {
                    argInputPath = args[i + 1];
                }
                else if (args[i] == "--outputPath" && i + 1 < args.Length)
                {
                    argOutputPath = args[i + 1];
                }
            }

            string inputPath = Path.Join(projectPath, argInputPath);
            string outputPath = Path.Join(projectPath, argOutputPath);

            if (string.IsNullOrEmpty(inputPath))
            {
                throw new Exception("NULL_EMPTY_INPUT");
            }

            if (string.IsNullOrEmpty(outputPath))
            {
                throw new Exception("NULL_EMPTY__OUTPUT");
            }

            // CSV 파일 읽기
            var classDefList = ParseCsv(inputPath);
            GenerateClasses(classDefList, outputPath);
        }


        public static List<ClassDefinition> ParseCsv(string inputPath)
        {
            var files = Directory.GetFiles(inputPath);
            var classDefinitionList = new List<ClassDefinition>();

            foreach (var file in files)
            {
                if (!file.EndsWith(".csv"))
                {
                    continue;
                }

                var lines = File.ReadAllLines(file);

                // 첫 번째 줄은 헤더
                for (int i = 1; i < lines.Length; i++)
                {
                    var values = lines[i].Split(',');
                    if (values[0].StartsWith("#"))
                    {
                        // 주석 무시
                        continue;
                    }

                    classDefinitionList.Add(new ClassDefinition
                    {
                        ClassInfo = values[0],
                        ClassName = values[1],
                        FieldName = values[2],
                        FieldType = values[3],
                        Idx = int.Parse(values[4]),
                        Description = values[5],
                        ProtocolName = values.Length > 6 ? values[6] : string.Empty
                    });
                }

            }
            return classDefinitionList;
        }

        public static void GenerateClasses(List<ClassDefinition> classDefinitions, string output)
        {
            var projectPath = GetProjPath();
            string templatePath = Path.Join(projectPath, "Template");
            string basicTemplatePath = Path.Join(templatePath, "PacketTemplate.txt");
            string reqTemplatePath = Path.Join(templatePath, "ReqPacketTemplate.txt");
            string resTemplatePath = Path.Join(templatePath, "ResPacketTemplate.txt");
            _pakTemplate = File.ReadAllText(basicTemplatePath);
            _reqPakTemplate = File.ReadAllText(reqTemplatePath);
            _resPakTemplate = File.ReadAllText(resTemplatePath);

            var groupedClassDict = new Dictionary<string, List<ClassDefinition>>();

            // 클래스 이름별로 필드 그룹화
            foreach (var definition in classDefinitions)
            {
                if (!groupedClassDict.ContainsKey(definition.ClassName))
                    groupedClassDict[definition.ClassName] = new List<ClassDefinition>();
                groupedClassDict[definition.ClassName].Add(definition);
            }

            //var parsedTemplate = Template.Parse(template);
            foreach (var (className, defList) in groupedClassDict)
            {
                var template = "";
                var classAttribute = "[ProtoContract]";
                var firstDef = defList.First();
                var protocolName = "";
                switch (firstDef.ClassInfo)
                {
                    case "req":
                        template = _reqPakTemplate;
                        classAttribute = "[ProtoContract]";
                        protocolName = firstDef.ProtocolName;
                        defList.Insert(0, new ClassDefinition { FieldName = "Info", FieldType = "ReqInfoPacket", Idx = 1 , FieldValue = ""});
                        break;
                    case "res":
                        template = _resPakTemplate;
                        classAttribute = "[ProtoContract]";
                        defList.Insert(0, new ClassDefinition { FieldName = "Info", FieldType = "ResInfoPacket", Idx = 1 , FieldValue = "= new();" });
                        break;
                    default:
                        template = _pakTemplate;
                        break;
                }

                var parsedTemplate = Template.Parse(template);
                var fields = new dynamic[defList.Count];
                for (var i =0; i< defList.Count; i++)
                {
                    var attribute = $"[ProtoMember({defList[i].Idx})]";
                    fields[i] = new Dictionary<string, object> {
                        {"Type",  defList[i].FieldType },
                        {"Name",  defList[i].FieldName },
                        { "Attribute",  attribute },
                         {"Value",  defList[i].FieldValue},
                    };

                }

                var classNameWithPak = $"{className}Packet";
                var scriptObject = new Dictionary<string, object>
                {
                    { "ClassName",  classNameWithPak},
                    { "ClassAttribute", classAttribute},
                    { "Fields", fields},
                    { "ProtocolName", protocolName}
                };

                var result = parsedTemplate.Render(scriptObject);

                var fileName = $"{classNameWithPak}.generated.cs";
                var outputFilePath = Path.GetFullPath(Path.Join(output, fileName));
                // 디렉토리 경로를 추출
                var directoryPath = Path.GetDirectoryName(outputFilePath);

                // 디렉토리가 없으면 생성
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(outputFilePath, result);
            }
        }

        private static string GetProjPath()
        {
            var exeCfgDirNetPath = Path.GetDirectoryName(AppContext.BaseDirectory);
            var exeCfgDirPath = Path.GetDirectoryName(exeCfgDirNetPath);
            var binDirPath = Path.GetDirectoryName(exeCfgDirPath);
            var projectPath = Path.GetDirectoryName(binDirPath);
            return projectPath == null? string.Empty : projectPath;
        }

        private static string _pakTemplate = string.Empty;
        private static string _reqPakTemplate = string.Empty;
        private static string _resPakTemplate = string.Empty;
    }

    public class ClassDefinition
    {
        public string ClassInfo { get; set; }
        public string ClassName { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldValue { get; set; }
        public int Idx { get; set; }
        public string Description { get; set; }
        public string ProtocolName { get; set; }
    }
}
