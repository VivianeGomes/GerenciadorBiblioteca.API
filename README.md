# 📚 Scriptoria – Gerenciador de Biblioteca

Sistema modular para gerenciamento de acervo, usuários e empréstimos de uma biblioteca.
Desenvolvido com foco em boas práticas de **arquitetura limpa**, separação de responsabilidades e evolução entre **Console App → API REST**.

---

## ✨ Funcionalidades

- Cadastro e listagem de livros
- Cadastro de usuários
- Registro de empréstimos
- Remoção e consulta por ID
- Validações e mensagens de erro amigáveis
- Implementação em camadas: Domain, Infra, App, API
- Pronto para testes unitários

---

## 🛠️ Tecnologias e Conceitos

- .NET (C#)
- Arquitetura em camadas inspirada na Clean Architecture
- Injeção de dependência
- Console App com navegação por menu
- API planejada com ASP.NET Core e Entity Framework Core

---

## 📂 Estrutura da Solução

```
GerenciadorBiblioteca.sln
├── GerenciadorBiblioteca.Domain/
├── GerenciadorBiblioteca.Infra/
├── GerenciadorBiblioteca.App/
├── GerenciadorBiblioteca.Api/
└── GerenciadorBiblioteca.Tests/
```

---

## 🔖 Status do Projeto

📍  **Versão 1: Console App** – em desenvolvimento

🌐 **Versão 2: Web API** – em planejamento

🧪 **Testes unitários** – estrutura inicial criada

---

## 📘 Por que começar com Console App?

> “Não é retrocesso começar simples — é inteligência arquitetural crescer sobre base sólida.”

Este projeto teve início com uma aplicação console para focar na arquitetura do domínio, regras de negócio e separação de responsabilidades — pavimentando o caminho para evoluir de forma organizada e consistente para uma Web API robusta.

---

## 💡 Para contribuir

Este projeto é um exercício de aprendizado contínuo. Sugestões e ideias são sempre bem-vindas!

---

## 📄 Licença

Licenciado sob a [Licença MIT](LICENSE).
