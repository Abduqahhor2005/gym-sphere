# GymSphere

GymSphere - это приложение для управления спортивным залом, включая управление тренерами, участниками, расписаниями и бронированиями.

## Содержание

- [Требования](#требования)
- [Установка](#установка)
- [Структура проекта](#структура-проекта)
- [Использование](#использование)

## Требования

- .NET 6.0 или выше
- Postgres или другая поддерживаемая база данных
- Entity Framework Core

## Установка

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/Abduqahhor2005/gym-sphere.git

## Структура проекта

- BaseEntity: базовый класс для всех сущностей с общими свойствами.
- Person: абстрактный класс для общих свойств участников и тренеров.
- Trainer: класс, представляющий тренера с опытом и специализацией.
- Member: класс, представляющий участника с датой регистрации.
- Schedule: класс, представляющий расписание занятий.
- Booking: класс, представляющий бронирование.
- Gym: класс, представляющий спортивный зал.

## Использование
- После настройки и запуска приложения вы сможете:

1. Добавлять, редактировать и удалять тренеров и участников.
2. Создавать и управлять расписаниями занятий.
3. Оформлять бронирования для участников.
4. Просматривать информацию о спортивном зале.