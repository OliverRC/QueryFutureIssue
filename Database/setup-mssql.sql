create database appdb
go

create schema dbo
go

create table People
(
    Id        int identity
        constraint People_pk
            primary key,
    Name      varchar(255) not null,
    Email     varchar(255) not null,
    ShirtSize varchar(255) not null
)
go