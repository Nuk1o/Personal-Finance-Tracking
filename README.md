# Консольное .NET приложение для учета личных финансов
## Приложение написано с использованием чисто архитектуры
<img width="650" height="370" alt="{870D91CC-D1ED-434A-93B2-15031791001C}" src="https://github.com/user-attachments/assets/31642c12-df63-4c7c-a2a1-b720d80915b6" />

## Работа приложения
![work](https://github.com/user-attachments/assets/8d17dbd5-bcfe-4e67-a365-430880ef7660)

## Входные данные
>Данные получены из json файла
>userWallets.json
```json
[
  {
    "Id": 0,
    "Name": "T-Bank",
    "Currency": 2,
    "BaseBalance": 500,
    "Transactions": [
      {
        "Id": 0,
        "Date": "2025-10-10T00:00:00",
        "Sum": 300,
        "TransactionType": 0,
        "Description": "salary"
      },
      {
        "Id": 1,
        "Date": "2025-10-15T00:00:00",
        "Sum": 150,
        "TransactionType": 1,
        "Description": "groceries"
      },
      {
        "Id": 2,
        "Date": "2025-11-12T00:00:00",
        "Sum": 200,
        "TransactionType": 0,
        "Description": "freelance payment"
      },
      {
        "Id": 3,
        "Date": "2025-11-12T00:00:00",
        "Sum": 200,
        "TransactionType": 1,
        "Description": "test"
      },
      {
        "Id": 4,
        "Date": "2025-11-12T00:00:00",
        "Sum": 10,
        "TransactionType": 1,
        "Description": "test"
      },
      {
        "Id": 5,
        "Date": "2025-11-12T00:00:00",
        "Sum": 5,
        "TransactionType": 1,
        "Description": "test"
      },
      {
        "Id": 6,
        "Date": "2025-11-12T00:00:00",
        "Sum": 250,
        "TransactionType": 1,
        "Description": "test"
      }
    ]
  },
  {
    "Id": 1,
    "Name": "Sber",
    "Currency": 1,
    "BaseBalance": 125,
    "Transactions": [
      {
        "Id": 0,
        "Date": "2025-10-21T00:00:00",
        "Sum": 100,
        "TransactionType": 1,
        "Description": "loan repayment"
      },
      {
        "Id": 1,
        "Date": "2025-11-08T00:00:00",
        "Sum": 25,
        "TransactionType": 0,
        "Description": "refund"
      },
      {
        "Id": 2,
        "Date": "2025-10-12T00:00:00",
        "Sum": 200,
        "TransactionType": 0,
        "Description": "subscription"
      }
    ]
  },
  {
    "Id": 2,
    "Name": "Alfa",
    "Currency": 2,
    "BaseBalance": 1500,
    "Transactions": [
      {
        "Id": 0,
        "Date": "2025-10-18T00:00:00",
        "Sum": 1000,
        "TransactionType": 0,
        "Description": "initial deposit"
      },
      {
        "Id": 1,
        "Date": "2025-11-06T00:00:00",
        "Sum": 350,
        "TransactionType": 1,
        "Description": "equipment purchase"
      },
      {
        "Id": 2,
        "Date": "2025-11-11T00:00:00",
        "Sum": 50,
        "TransactionType": 0,
        "Description": "cashback"
      },
      {
        "Id": 3,
        "Date": "2025-11-05T00:00:00",
        "Sum": 200,
        "TransactionType": 1,
        "Description": "tax payment"
      }
    ]
  },
  {
    "Id": 3,
    "Name": "VTB",
    "Currency": 0,
    "BaseBalance": 65,
    "Transactions": [
      {
        "Id": 0,
        "Date": "2025-11-10T00:00:00",
        "Sum": 20,
        "TransactionType": 1,
        "Description": "ice cream"
      },
      {
        "Id": 1,
        "Date": "2025-10-23T00:00:00",
        "Sum": 1000,
        "TransactionType": 0,
        "Description": "holiday bonus"
      }
    ]
  }
]
```

## Запуск приложения
Скачайте актуальную версию билда из релиза<br>
[Скачать проект](https://github.com/Nuk1o/Personal-Finance-Tracking/releases/tag/release)
>Проверьте наличие файла "userWallets.json", он должен находиться рядом с файлом "Finance Tracking.exe"
