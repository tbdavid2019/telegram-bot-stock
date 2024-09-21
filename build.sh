docker build -t telegram-bot-stock . --no-cache
docker run -d --name telegram-bot-stock telegram-bot-stock

docker tag telegram-bot-stock tbdavid2019/telegram-bot-stock:latest
docker push tbdavid2019/telegram-bot-stock:latest

