# Parking
Sistema de estacionamento, capaz de realizar o gerenciamento de veículos, tickets e vagas de estacionamento

# Tecnologias
| Descrição | Versão | 
|-------------|-------------|
| C#                | 12.0        |
| .NET Core         | 8.0.3       |
| Entity Framework  | 8.0.3       |
| MySQL             | 10.4.24     |

# Instruções de configuração
1) Instale as dependências do projeto
2) Crie uma conexão local com o banco de dados MySQL. O projeto já possui uma string de conexão previamente configurada, adapte-a caso necessário
3) Execute as migrations, pode ser necessário instalar a referente ferramenta do Entity Framework para executá-las
4) O servidor estará disponível na porta 5000

# Decisões Arquiteturais
O projeto foi dividido em três camadas: Controllers, UseCases e Repositories. Essa decisão foi tomada para reduzir as responsabilidades dos métodos presentes no sistema, sendo as "controllers" responsáveis bascicamente por receber as requisições e devolver uma resposta, os "use cases" por possuírem as regras de negócio e os "repositories" por realizar as ações relacionadas ao banco de dados. Além disso, o projeto também possui Interfaces, estruturas que auxiliaram a reduzir o acoplamento entre classes por meio da inverção de dependências. DTO's estão presentes para organizar melhor a transferência de objetos, já as Migrations permitem documentar e padronizar as alterações feitas no banco de dados ao longo do desenvolvimento.

# Requisitos de Projetos Atendidos
A lista abaixo representa os requisitos de projeto e o respectivo "end-point"/funcionalidade que atende cada um deles:
1) Quantas vagas restam? - "v1/ParkingSpace/SumAvailableParkingSpaces"
2) Quantas vagas totais há no estacionamento? - "v1/ParkingSpace/SumParkingSpaces"
3) Estacionamento está cheio? - "v1/ParkingSpace/CheckParkingIsAbsolutelyFull"
4) Estacionamento está vazio? - "v1/ParkingSpace/CheckParkingIsEmpty"
5) Alguns dos setores está cheio - Essa verificação é feita no ParkingSpaceUseCase e não em um "end-point" específico
6) Quantas vagas as vans estão ocupando? - "v1/ParkingSpace/SumVanParkingSpaces"

# Observações Finais
1) O projeto contaria também com um front-end dedicado, porém o tempo de desenvolvimento(aproximadamente 10 horas) foi insuficiente. Dessa forma, fica como sugestão a implementação
2) Qualquer dúvida ou problema durante a utilização do sistema, favor me informar para que possa auxiliar
