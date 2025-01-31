# Criador de Lembretes

Este é um projeto full-stack desenvolvido com **.NET** no backend e **React** no frontend. Ele permite criar, visualizar e excluir lembretes, utilizando um banco de dados **SQLite**.

## Tecnologias Utilizadas

### Backend:
- **ASP.NET Core**
- **Entity Framework Core**
- **SQLite**
- **Swagger** (documentação da API)

### Frontend:
- **React**
- **Vite**
- **Styled-Components**

---
## Como Rodar o Projeto

### 1️⃣ Configurando o Backend (API .NET)

1. **Instale as dependências do SQLite** caso ainda não tenha:
   ```sh
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   ```

2. **Navegue até a pasta do backend:**
   ```sh
   cd backend
   cd ReminderAPI
   ```

3. **Instale as dependências do projeto:**
   ```sh
   dotnet restore
   ```

4. **Inicie a API:**
   ```sh
   dotnet run
   ```

A API agora estará rodando e disponível no seguinte endereço:
   ```
   https://localhost:7102
   ```

5. **Acesse a documentação Swagger:**
   ```
   https://localhost:7102/swagger
   ```

---

### 2️⃣ Configurando o Frontend (React)

1. **Navegue até a pasta do frontend:**
   ```sh
   cd frontend
   ```

2. **Instale as dependências principais:**
   ```sh
   npm install vite@latest
   npm install styled-components
   ```

3. **Inicie o frontend:**
   ```sh
   npm run dev
   ```

4. **Abra a URL indicada no terminal** (geralmente `http://localhost:5173`) para acessar a aplicação web.

---


