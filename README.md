# MeFerstWebAplication
Добро пожаловать на мой первый проект на ASP.NET Framework 6.0 <br/>
Цель данного проекта освоить основы разработки Web <br/>
Структура проекта строится на паттерне MVC <br/>
Для хранения данных используется EntityFrameworkCore.SqlServer 6.0.7 <br/>

В основе представления использутеся Razor(html+css) <br/>
Вся основная логическая часть написана на чистом с# <br/>

В проекте реализованно
- Система регистрации пользователей и доступа пользователя по ролям (Admin, User). Сама система реализована с помощью аутентификации на основе куки.
- Реализована система новостной ленты (вкладка Blog). Просмотр ленты имеют доступ все пользователи, добавлять только авторизованные пользователи, удалять только пользователь с ролью Admin.
- В новостной ленте (Blog) реализована сортировка по категориям и дате добавления поста(в преспективе поиск по контенту)

## Преспективы проекта 
- Реализовать более польную систему пользователей ( Страницу просмотра данных пользователя, изменения данных).
- Реализовать функционал роли Admin. Просмотр аккаунто, удаление и изменение данных, установка роли Admin.
- Доделать регистрацию пользователей с подтверждением эллектронной почты.
- Написание адаптивного представления сайта, под разные платформы(телефон, планшет, компьютер).
- Использование анимаций на основе JS.
- Реализовать полную валидацию данных вводимых пользвателем.

# Если что, пользователь c ролью Admin 
- Login: 1
- Password: 1
