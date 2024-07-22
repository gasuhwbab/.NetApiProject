Для создания образа:
docker build --no-cache -t evaluations_web_api .
Для запуска контейнера:
docker run -d -p 4040:4040 evaluations_web_api:latest 