O JusFácil é um sistema web desenvolvido para auxiliar minha mãe advogada que, em 25 anos de profissão autônoma, administra seu negócio 
em pastas na área de trabalho, agenda física, e-mail e conversas no WhatsApp. Foi pensando em facilitar o dia a dia dela que criei o JusFacil
com o objetivo de centralizar e facilmente gerenciar clientes, processos, atendimentos e financeiro. Dessa forma posso facilitar o 
acompanhamento de casos e tornar o controle financeiro mais preciso e acessível. 
A proposta é permitir que minha mãe e quem sabe num futuro próximo, outros advogados autônomos e suas e equipes administrativas tenham uma visão 
clara e organizada das atividades, melhorando a produtividade e a tomada de decisões.

No backend, o sistema utiliza .NET 8 com ASP.NET Core Web API, proporcionando uma arquitetura robusta e segura. 
O Entity Framework Core foi adotado como ORM para gerenciamento do banco de dados, e atualmente a aplicação está 
configurada para usar SQLite, embora seja possível migrar para bancos mais robustos, como PostgreSQL, no futuro. 
A autenticação é feita por meio de JWT (JSON Web Token), garantindo segurança no controle de acesso aos recursos.

O frontend será desenvolvido em React.js, com uso de bibliotecas modernas como Axios para consumo de APIs, React Router 
para gerenciamento de rotas e Context API (ou Redux, dependendo das necessidades futuras) para controle de estado.

Até o momento, algumas regras de negócio já foram definidas. O número do processo é sempre informado manualmente pelo usuário, 
pois corresponde ao registro oficial no sistema judiciário. Clientes não acessam o sistema; todas as interações são realizadas 
por usuários internos, como advogados e administradores. Os registros de pagamento exigem que o usuário informe manualmente 
a data e a forma de pagamento, além do valor pago.

O módulo de usuários já conta com um CRUD completo, com regras específicas: apenas administradores podem criar ou excluir usuários, 
enquanto cada usuário pode atualizar apenas suas informações básicas, como e-mail e senha. O módulo de clientes também possui um 
CRUD básico já implementado. O módulo de processos permite consulta detalhada pelo número do processo, facilitando a busca para os usuários. 
No módulo financeiro, foram implementados métodos para verificar se o pagamento está quitado, atualizar status automaticamente, 
registrar novos pagamentos, definir valores totais e calcular saldo pendente.

Nas próximas etapas, será concluído o CRUD de atendimentos, incluindo a funcionalidade de anexar documentos com restrições de formato. 
Em seguida, será desenvolvido o frontend, integrando todas as funcionalidades da API em uma interface intuitiva e eficiente. 
Por fim, serão criadas páginas de relatórios para acompanhamento gerencial, além de ajustes finais nas regras de autorização e refinamentos gerais.

Este projeto é resultado de estudo prático e desenvolvimento solo, com o objetivo de consolidar conhecimentos em arquitetura de sistemas, 
APIs seguras e boas práticas de desenvolvimento web. A documentação, os métodos e os fluxos foram pensados para refletir as necessidades reais 
de um escritório de advocacia, aproximando o projeto de um cenário profissional.

