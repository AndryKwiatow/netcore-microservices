docker run --name maria-database -p 3310:3306 -p 33061:33060  -e MYSQL_ROOT_PASSWORD=Aforo255#2019 -d mariadb:10.2.36 

docker run --name maria-database -p 3310:3306 -p 33061:33060  -e MYSQL_ROOT_PASSWORD=Aforo255#2019 -d mariadb:10.2.36 --character-set-server=utf8mb4 --collation-server=utf8mb4_unicode_ci