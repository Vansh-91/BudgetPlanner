# 💰 Budget Planner

A sleek and powerful Budget Planner app to manage your income, expenses, and savings. Built with **ASP.NET Core**, **Chart.js**, and a dark-themed responsive design, this app offers intuitive controls to track spending, set category limits, and visualize financial data over time.

## 🔧 Features

- ✅ Add, edit, and delete income/expense transactions
- 📊 Visualize daily, monthly, and category-wise spending with charts
- 🧠 Set budget limits with alerts on overspending
- 🔎 Search and filter by category, type, or keyword
- 🌗 Beautiful dark theme UI with responsive layout
- 👥 Multi-user login system (ASP.NET Identity)
- 📤 Export reports to Excel or PDF

## 🛠️ Tech Stack

- **Frontend:** HTML, CSS, JavaScript, Chart.js
- **Backend:** ASP.NET Core MVC
- **Database:** SQL Server
- **Authentication:** ASP.NET Identity
- **Exporting:** EPPlus (Excel), PdfSharpCore (PDF)

## 🚀 Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- SQL Server
- Visual Studio or VS Code

### Run Locally

```bash
git clone https://github.com/your-username/budget-planner.git
cd budget-planner
dotnet restore
dotnet ef database update
dotnet run
