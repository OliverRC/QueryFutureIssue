CREATE DATABASE IF NOT EXISTS `appdb`;

USE `appdb`;

create or replace table People
(
    Id        int auto_increment
        primary key,
    Name      varchar(255) not null,
    Email     varchar(255) not null,
    ShirtSize varchar(5)   not null
);
