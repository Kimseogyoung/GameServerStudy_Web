:@ECHO OFF

SET USER_NAME=%1
SET USER_PASSWORD=%2
SET DB_NAME=%3
SET CHANGE_LOG_PATH=%4
liquibase ^
  --url="jdbc:mysql://localhost:3306/%DB_NAME%" ^
  --username="%USER_NAME%" ^
  --password="%USER_PASSWORD%" ^
  --driver="com.mysql.cj.jdbc.Driver" ^
  --changeLogFile="%CHANGE_LOG_PATH%" ^
  status