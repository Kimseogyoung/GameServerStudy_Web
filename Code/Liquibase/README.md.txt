## Liquibase 사용법

- db 상태 확인
```
liquibase status

liquibase ^
  --url="jdbc:mysql://localhost:3306/your_database_name" ^
  --username="your_username" ^
  --password="your_password" ^
  --driver="com.mysql.cj.jdbc.Driver" ^
  --changeLogFile="UserDbChangeLog.yml" ^
  status
```

- db 스키마 적용
```
liquibase update

liquibase ^
  --url="jdbc:mysql://localhost:3306/your_database_name" ^
  --username="your_username" ^
  --password="your_password" ^
  --driver="com.mysql.cj.jdbc.Driver" ^
  --changeLogFile="UserDbChangeLog.yml" ^
  update
```
적용 시 `DATABASECHANGELOG` 테이블에 로그 기록

- 롤백 (최신 1개 되돌리기)
```
liquibase rollbackCount 1

liquibase ^
  --url="jdbc:mysql://localhost:3306/AuthDb" ^
  --username="your_username" ^
  --password="your_password" ^
  --driver="com.mysql.cj.jdbc.Driver" ^
  --changeLogFile="AuthDbChangeLog.yml" ^
  rollbackCount 1
```

- JDBC 드라이버 설정
MySQL의 경우, mysql-connector-java JAR 파일을 Liquibase 설치 디렉토리의 lib 폴더에 추가해야 한다고 함.
https://dev.mysql.com/downloads/connector/j/에서 다운받은 `mysql-connector-j-9.0.0` 파일을 liquibase설치 폴더 lib 폴더로 이동.


- TODO: 자동화 (팀시티, 젠킨스)

- 참고 사항 : Db는 직접 만들어야 함.
```
Create Database AuthDb
```