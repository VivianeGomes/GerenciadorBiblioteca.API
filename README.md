# 🧪 Documentação Técnica da API REST – Scriptoria

Uma camada encantada que conecta o universo da aplicação aos desenvolvedores e consumidores externos — tudo com clareza, elegância e boas práticas REST. ✨

---

## 🚀 Como Executar a API Localmente

🧰 Pré-requisitos:

- .NET SDK 7.0 ou superior instalado
- Git configurado no ambiente
- Editor de código recomendado: Visual Studio ou VS Code

---

### 🧭 Etapas iniciais para subir o projeto

1. **Clone o repositório**

   ```bash
   git clone https://github.com/VivianeGomes/GerenciadorBiblioteca.API
   ```

2. **Navegue até a pasta raiz**

   ```bash
   cd GerenciadorBiblioteca.API
   ```

3. **Restaure os pacotes NuGet**

   ```bash
   dotnet restore
   ```

4. **Execute a API**

   ```bash
   dotnet run --project GerenciadorBiblioteca.Api
   ```

5. **Acesse o Swagger**
   Abra seu navegador e vá para:  
   `https://localhost:5001/swagger`

🎉 Pronto! A interface interativa estará disponível para explorar os endpoints.

---

> 💡 **Dica:** Se estiver usando VS Code, basta abrir a pasta raiz e apertar `F5` para rodar em modo debug com a configuração padrão.

> 🔎 **Observação:** Caso esteja em Linux/macOS, adapte o caminho de arquivos e use `export` no lugar de `$env:` se estiver usando variáveis de ambiente.

---

## 🔗 Padrões de Endpoints

- 🏰 **Base URL**: `https://localhost:5001/api`
- 🧭 **Formato de rota**: `/[controller]/[action]`
- 📦 **Content-Type**: `application/json`
- 🌱 **Versionamento planejado**: `/v1/livros`, `/v1/usuarios`, etc.

---

## 📦 Estrutura de Respostas

```json
{
  "sucesso": true,
  "dados": { ... },
  "erros": []
}
```

- ✅ `sucesso`: indica êxito na operação
- 📚 `dados`: o conteúdo retornado (objeto, lista, etc.)
- 🚨 `erros`: lista de mensagens explicando falhas (se houver)

---

## 🧰 Tratamento de Erros

- As validações ocorrem nos **Services**, com mensagens claras
- Os **Controllers** retornam erro genérico + mensagens amigáveis
- Um **Middleware personalizado** intercepta exceções e responde com formato padrão

---

## 🧾 Códigos HTTP Utilizados

| Código | Descrição                                  |
| ------ | ------------------------------------------ |
| 200    | ✅ OK – operação bem-sucedida              |
| 201    | ✨ Created – recurso criado                |
| 400    | ❌ Bad Request – erro na requisição        |
| 404    | 🔍 Not Found – recurso não encontrado      |
| 500    | 💥 Internal Server Error – exceção interna |

---

## 🗂️ Convenções dos DTOs

- Os modelos de entrada usam `string?` para valores opcionais
- O domínio utiliza `string.Empty` como padrão
- Evita-se a exposição direta do `ModelState`

---

## 📘 POST `/livros` – Cadastrar Novo Livro

**🛠️ Detalhes:**

- **URL**: `https://localhost:5001/api/livros`
- **Método**: `POST`
- **Cabeçalhos**:
  - `Content-Type: application/json`

**📨 Payload:**

```json
{
  "titulo": "O Senhor dos Anéis",
  "autor": "J.R.R. Tolkien",
  "anoPublicacao": 1954,
  "genero": "Fantasia"
}
```

**✅ Resposta de sucesso:**

```json
{
  "sucesso": true,
  "dados": {
    "id": 42,
    "titulo": "O Senhor dos Anéis",
    "autor": "J.R.R. Tolkien",
    "anoPublicacao": 1954,
    "genero": "Fantasia"
  },
  "erros": []
}
```

**❌ Exemplo de falha:**

```json
{
  "sucesso": false,
  "dados": null,
  "erros": ["O campo 'titulo' é obrigatório.", "Ano de publicação inválido."]
}
```

---

## 📄 Licença

Este projeto está licenciado sob os termos da [MIT License](https://opensource.org/licenses/MIT).

---

> 🧱 **Construção em andamento**  
> Esse projeto ainda tá ganhando forma — mais detalhes, exemplos e encantos técnicos virão nos próximos commits. Fica por perto! 🚀
