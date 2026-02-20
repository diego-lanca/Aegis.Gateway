# 🛡️ Aegis Gateway

Um **API Gateway em ASP.NET Core** focado em **segurança, extensibilidade e boas práticas de arquitetura**, criado como projeto de portfólio para demonstrar domínio de:

- pipeline HTTP com middlewares
- autenticação baseada em estratégia
- separação de responsabilidades
- design preparado para múltiplos tipos de credenciais

> O objetivo do projeto não é ser apenas um CRUD, mas sim um gateway real, com arquitetura pronta para crescer (auth, rate limit, logging, etc).

---

## 🎯 Objetivo

O **Aegis Gateway** atua como um ponto central de entrada para APIs, sendo responsável por:

- autenticação
- (futuramente) rate limiting
- logging
- controle de acesso por tipo de cliente
- integração com múltiplos serviços

---

## ✨ Funcionalidades atuais

- Middleware de autenticação centralizado
- Resolução de autenticação por **strategy pattern**
- Suporte a múltiplos esquemas de autenticação
- Parse seguro do header `Authorization`
- Pipeline que bloqueia requisições inválidas antes de atingir os controllers

Atualmente implementado:

- ✅ Bearer authentication (mock / base estrutural)

---

## 🧠 Arquitetura de autenticação

```
AuthMiddleware
↓
AuthResolver
↓
IAuthHandler
├── BearerAuthHandler
└── (futuro) ApiKeyAuthHandler
```

O middleware **não conhece** implementações concretas de autenticação.  
Ele apenas resolve o handler correto de acordo com o *scheme* informado no header.

---

## 🔐 Exemplo de requisição

```
Authorization: Bearer <token>
```


O gateway:

1. valida o formato do header
2. resolve o handler de autenticação
3. executa a validação
4. só encaminha a requisição se estiver válida

---

## 🚧 Próximos passos (roadmap)

- [ ] Autenticação por ApiKey utilizando MongoDB
- [ ] Cadastro e gerenciamento de chaves de acesso
- [ ] Cache de validação
- [ ] Rate limit por cliente
- [ ] Escopos e permissões
- [ ] Logging estruturado
- [ ] Forward/proxy de requisições para serviços internos

---

## 🛠️ Tecnologias

- ASP.NET Core
- C#
- Middleware pipeline
- Dependency Injection nativo
- MongoDB (planejado)

---

## 🎓 Motivação

Este projeto foi criado com foco em aprendizado avançado de backend e arquitetura,
indo além de APIs tradicionais, simulando cenários reais de gateways e infraestrutura.

Ele faz parte do meu portfólio como estudante de Engenharia da Computação.

---

## ▶️ Como rodar

```bash
dotnet restore
dotnet run
```

📌 Observação

Este projeto está em evolução contínua e foi construído passo a passo com foco
em boas práticas, clareza arquitetural e facilidade de extensão.
