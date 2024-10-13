메모

클래스 용도
- Controller : Api처리 (Service호출 )
- Sevice : Api 각 함수 처리(Controller와 역할이 겹치는데 Sevice는 배치처리 대비용)
- ??? : 모델별로 검증 및 UserRepo 호출 (여기서 필요한 변수 저장) -> 네이밍 정리 필요, 예시 프로젝트는 Infomation... 뭐이런거인듯. 
- UserRepo : 실제 쿼리 및 캐싱


- Middleware : 요청 정보 로드 및 압축 암호화, 디시리얼라이즈
- Filter : 로그, 인증, 트랜잭션 등
- ExceptionHandler : 에러 잡아서 ResultCode로 리턴 