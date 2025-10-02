# 25E2_4_AT-SistemaTurismo
Tema ou domínio do sistema:

Sistema de gerenciamento para uma agência de turismo que oferece pacotes turísticos, cadastro de clientes, reservas e controle de disponibilidade de destinos.

Entidades principais:

Cliente, CidadeDestino, PaisDestino, PacoteTuristico, Reserva

Regras de negócio relevantes:

Um pacote turístico pode incluir vários destinos.
Um cliente pode realizar várias reservas, mas não pode reservar o mesmo pacote mais de uma vez para a mesma data.
Cada pacote turístico tem um número máximo de participantes; ao atingir esse número, novas reservas são bloqueadas.
Apenas pacotes com data futura e vagas disponíveis podem ser reservados.
