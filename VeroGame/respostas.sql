-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 30-Out-2017 às 16:18
-- Versão do servidor: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vero_developer`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `respostas`
--

CREATE TABLE `respostas` (
  `Texto` text,
  `ValorMin` decimal(8,3) DEFAULT NULL,
  `ValorMax` decimal(8,3) DEFAULT NULL,
  `ValorIntervalo` decimal(8,3) DEFAULT NULL,
  `Ativo` tinyint(1) DEFAULT NULL,
  `idPergunta` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `Ordem` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `respostas`
--

INSERT INTO `respostas` (`Texto`, `ValorMin`, `ValorMax`, `ValorIntervalo`, `Ativo`, `idPergunta`, `id`, `Ordem`) VALUES
('=SOMASES(Valor;Data da Venda;B16;Nome;B17)', NULL, NULL, NULL, NULL, 3, 11, NULL),
('=SOMASES(Valor; Nome;B17;Data da Venda;B16)', NULL, NULL, NULL, NULL, 3, 12, NULL),
('=SOMARPRODUTO((Data=B16)*(Nome do Vendedor=B17)*Valor))', NULL, NULL, NULL, NULL, 3, 13, NULL),
('Todas as respostas acima levarão ao valor correto', NULL, NULL, NULL, NULL, 3, 14, NULL),
('	Conversa direto com seu superior para obter orientações sobre como proceder com este erro.	', NULL, NULL, NULL, NULL, 18, 15, NULL),
('	Imediatamente envia um segundo e-mail explicando seu erro, assim este pode ser deletado. Depois você envia o e-mail para a pessoa certa.	', NULL, NULL, NULL, NULL, 18, 16, NULL),
('	No sistema você resgata seu e-mail e envia-o para a pessoa certa.	', NULL, NULL, NULL, NULL, 18, 17, NULL),
('	Vai diretamente a mesa de seu colega para explicá-lo seu erro e deletar o e-mail. Depois você envia o e-mail para a pessoa certa.	', NULL, NULL, NULL, NULL, 18, 18, NULL),
('	Busca completar seu trabalho fazendo o melhor que pode. Solicita o suporte de um colega experiente para revisar o trabalho, assim você pode fazer alterações, se necessário.	', NULL, NULL, NULL, NULL, 19, 19, NULL),
('	Conversa com o Líder de Projeto sobre suas preocupações e solicita um plano de treinamento rápido para adquirir o conhecimento requisitado.	', NULL, NULL, NULL, NULL, 19, 20, NULL),
('	Sugere ao Líder de Projeto que outra pessoa mais experiente complete as tarefas até que adquira o conhecimento.	', NULL, NULL, NULL, NULL, 19, 21, NULL),
('	Utiliza uma combinação de autoaprendizagem e conversas com especialistas de seu time para garantir que terá boa compreensão do conhecimento técnico que precisa.	', NULL, NULL, NULL, NULL, 19, 22, NULL),
('	Conversa com seu colega, explica a situação e lhe solicita que mude de comportamento.	', NULL, NULL, NULL, NULL, 20, 23, NULL),
('	Conversa com seu Líder e informa a situação para que ele encontre a solução.	', NULL, NULL, NULL, NULL, 20, 24, NULL),
('	Solicita a outro colega da equipe que entenda o que está acontecendo com este colega.	', NULL, NULL, NULL, NULL, 20, 25, NULL),
('	Você não reage, uma vez que seu colega possui forte relacionamento com seu Líder.	', NULL, NULL, NULL, NULL, 20, 26, NULL),
('	Apresenta as correlações que identificou e lhe informa de seus requisitos para terminar a análise.	', NULL, NULL, NULL, NULL, 21, 27, NULL),
('	Apresenta suas primeiras conclusões, mas informa a seu Líder que estas ainda precisam ser confirmadas.	', NULL, NULL, NULL, NULL, 21, 28, NULL),
('	Solicita a seu Líder postergar a reunião para finalizar a análise completamente.	', NULL, NULL, NULL, NULL, 21, 29, NULL),
('	Vai para o trabalho mais cedo para finalizar as atividades antes da reunião com seu Líder.	', NULL, NULL, NULL, NULL, 21, 30, NULL),
('	Informa a seu colega que deveria listar todas as questões que possui, assim você pode lhe dar suporte nos pontos de bloqueio e tem tempo suficiente para focar nas demandas urgentes.	', NULL, NULL, NULL, NULL, 22, 31, NULL),
('	Discute a situação com seu colega e com o Líder, para trabalharem juntos na priorização de atividades.	', NULL, NULL, NULL, NULL, 22, 32, NULL),
('	Informa a seu colega que necessita focar nas demandas urgentes. Aconselha-o a tentar completar o arquivo e que irá revisá-lo, caso tenha tempo.', NULL, NULL, NULL, NULL, 22, 33, NULL),
('	Explica a situação para seu colega e sugere que ele solicite outro suporte ao Líder para finalizar a tarefa.	', NULL, NULL, NULL, NULL, 22, 34, NULL),
('	Conversa com seu colega para identificar a causa raíz dos problemas e define a solução que irá seguir. 	', NULL, NULL, NULL, NULL, 23, 35, NULL),
('	Conversa com seu colega para listar todos os elementos que estão errados, assim seu Líder pode decidir como proceder para completar o projeto.	', NULL, NULL, NULL, NULL, 23, 36, NULL),
('	Prepara-se para justificar o que ocorreu de errado, defender seu trabalho e preservar sua reputação.	', NULL, NULL, NULL, NULL, 23, 37, NULL),
('	Revisa o briefing do projeto e o aborda na reunião de forma flexível e não planejada, mas define um plano de ação com seu Líder para completar o projeto. 	', NULL, NULL, NULL, NULL, 23, 38, NULL),
('	Informa seu Líder de Equipe de que você não possui tempo suficiente para modificar as análises e solicita que mantenha a hipótese inicial.	', NULL, NULL, NULL, NULL, 24, 39, NULL),
('	Questiona seu Líder de Equipe sobre a possibilidade de deixar isto de lado na análise em razão da falta de tempo.	', NULL, NULL, NULL, NULL, 24, 40, NULL),
('	Seleciona as partes de seu trabalho que estão corretas e estabelece um planejamento para finalizar análises extras no curto prazo.	', NULL, NULL, NULL, NULL, 24, 41, NULL),
('	Solicita seu Líder de Equipe que estenda o prazo para refazer as análises e fornecer conclusões corretas.	', NULL, NULL, NULL, NULL, 24, 42, NULL),
('	Envia um e-mail recordando-os da importância do projeto, mencionando claramente sua abordagem e indicando a eles que quando pensar nisto irá solicitar a colaboração de todos.	', NULL, NULL, NULL, NULL, 25, 43, NULL),
('	Informa seu Líder dos desafios que está enfrentando com seus colegas.	', NULL, NULL, NULL, NULL, 25, 44, NULL),
('	Organiza uma reunião com seus colegas, lhes recorda que é uma orientação global que vem de seu Líder de Equipe, e solicita a colaboração de todos.	', NULL, NULL, NULL, NULL, 25, 45, NULL),
('	Organiza uma reunião com seus colegas. Apresenta sua missão, abordagem e objetivos do projeto, para obter a validação de todos.	', NULL, NULL, NULL, NULL, 25, 46, NULL),
('	Através do trabalho dele, mostre os pontos de retrabalho para finalizar o relatório.	', NULL, NULL, NULL, NULL, 26, 47, NULL),
('	Discuta isto com seu membro de equipe para entender as razões de suas dificuldades e preparar um plano de ação para preencher os gaps de sua qualificação.	', NULL, NULL, NULL, NULL, 26, 48, NULL),
('	Indica que ele não deveria hesitar ir até você para validar os resultados.	', NULL, NULL, NULL, NULL, 26, 49, NULL),
('	Indica que um membro de equipe mais experiente irá revisar seu trabalho para validar os resultados.	', NULL, NULL, NULL, NULL, 26, 50, NULL),
('	Antes de conversar sobre sua avaliação, fale com ele sobre seu nível de motivação e interesse por este trabalho.	', NULL, NULL, NULL, NULL, 27, 51, NULL),
('	Conte a ele sua avaliação negativa e tente entender as razões para a mudança de comportamento.	', NULL, NULL, NULL, NULL, 27, 52, NULL),
('	Converse sobre suas atividades atuais e o oriente para que desenvolva um trabalho melhor. Analise a evolução de sua performance antes de tomar outras atitudes.	', NULL, NULL, NULL, NULL, 27, 53, NULL),
('	Diga a ele seu desapontamento com sua performance e que espera mais dele, baseando-se nas avaliações anteriores.	', NULL, NULL, NULL, NULL, 27, 54, NULL),
('	Monitora a performance e o comportamento dos membros de sua equipe e avalia os que mostram sinais de estresse para providenciar suporte.	', NULL, NULL, NULL, NULL, 28, 55, NULL),
('	Você organiza reuniões individuais com cada membro da equipe para avaliar a performance do time.	', NULL, NULL, NULL, NULL, 28, 56, NULL),
('	Durante uma reunião de equipe pergunta aos membros o que poderia ser melhorado no ambiente de trabalho para reduzir o nível de estresse.	', NULL, NULL, NULL, NULL, 28, 57, NULL),
('	Para manter bom ambiente e coesão de trabalho você solicita aos membros da equipe que organizem eventos fora do ambiente e horário de trabalho.	', NULL, NULL, NULL, NULL, 28, 58, NULL),
('	Evita modificar a forma de trabalho de seu time já que isto pode provocar problemas na criação dos relatórios semanais.	', NULL, NULL, NULL, NULL, 29, 59, NULL),
('	Recomenda a seu time que utilize a base de dados somente para relatórios importantes, para evitar perda de tempo no planejamento de trabalho da equipe.	', NULL, NULL, NULL, NULL, 29, 60, NULL),
('	Recomenda a seu time que utilize outros recursos para criar os relatórios semanais.	', NULL, NULL, NULL, NULL, 29, 61, NULL),
('	Utiliza a técnica de brainstorming com seu time para aprimorar a forma de criar os relatórios semanais de maneira mais eficiente.	', NULL, NULL, NULL, NULL, 29, 62, NULL),
('Aceitar regulamento', NULL, NULL, NULL, NULL, 30, 63, NULL),
('Conversa com o seu colega para entender a mudança de comportamento em relação a você.', NULL, NULL, NULL, NULL, 40, 64, NULL),
('Conversa com seu supervisor, explica a situação e solicita que ele ajuste suas atividades para que você possa continuar auxiliando o novo estagiário sem comprometer suas entregas.', NULL, NULL, NULL, NULL, 31, 65, NULL),
('Informa ao seu colega que você precisa focar nas suas atividades atrasadas e, caso sobre tempo, voltará a apoiá-lo.', NULL, NULL, NULL, NULL, 31, 66, NULL),
('Conversa com os demais colegas de trabalho e justifica o atraso na conclusão de algumas atividades em função da solicitação do seu supervisor para que auxiliasse o novo estagiário.', NULL, NULL, NULL, NULL, 31, 67, NULL),
('Busca o suporte de um colega para concluir algumas atividades menos importantes.', NULL, NULL, NULL, NULL, 31, 68, NULL),
('Não faz nada, já que o seu colega é muito próximo do seu supervisor.', NULL, NULL, NULL, NULL, 32, 69, NULL),
('Conversa com seu colega, explica os impactos no trabalho e solicita que ele altere seu comportamento.', NULL, NULL, NULL, NULL, 32, 70, NULL),
('Pede para outro membro da equipe conversar com seu colega para entender o que está ocorrendo com ele.', NULL, NULL, NULL, NULL, 32, 71, NULL),
('Procura seu supervisor e informa o que está acontecendo para que ele encontre uma solução.', NULL, NULL, NULL, NULL, 32, 72, NULL),
('Conversa novamente com o seu supervisor e solicita que ele reorganize suas atividades para que você possa participar do treinamento.', NULL, NULL, NULL, NULL, 33, 73, NULL),
('Informa ao seu supervisor que você desistiu de participar do treinamento já que somente uma parte do conteúdo está relacionado com seu trabalho atual.', NULL, NULL, NULL, NULL, 33, 74, NULL),
('Explica ao seu supervisor os benefícios do treinamento para sua carreira e como você poderá contribuir futuramente para a organização a partir deste aprendizado, apresentando alternativas para evitar impactos nas atividades de apoio à equipe.', NULL, NULL, NULL, NULL, 33, 75, NULL),
('Confirma com a área de recursos humanos sua participação na etapa do treinamento relacionada com suas atividades atuais, de forma a não prejudicar o apoio à equipe.', NULL, NULL, NULL, NULL, 33, 76, NULL),
('Informa educadamente ao seu colega que você avisará ao seu supervisor se ele continuar a fazer estas ligações.', NULL, NULL, NULL, NULL, 34, 77, NULL),
('Reporta o incidente ao seu supervisor sem dizer nada ao seu colega.', NULL, NULL, NULL, NULL, 34, 78, NULL),
('Não faz nada. Afinal, este assunto não lhe diz respeito e você não quer criar um problema de relacionamento.', NULL, NULL, NULL, NULL, 34, 79, NULL),
('Conversa com o seu colega, lembrando-o de que o uso do telefone para ligações pessoais desrespeita o regulamento interno da empresa.', NULL, NULL, NULL, NULL, 34, 80, NULL),
('Para evitar polêmicas, encerra o assunto dizendo que a atmosfera do grupo é boa.', NULL, NULL, NULL, NULL, 35, 81, NULL),
('Para o seu próprio bem, diz o que os outros colegas pensam dele.', NULL, NULL, NULL, NULL, 35, 82, NULL),
('Diz a ele, em particular, o que você acredita ser a fonte do problema, exemplificando algumas situações.', NULL, NULL, NULL, NULL, 35, 83, NULL),
('Fala que, em sua opinião, o motivo do clima hostil é o comportamento dele com as pessoas.', NULL, NULL, NULL, NULL, 35, 84, NULL),
('Prepara-se individualmente para justificar o que deu errado, defendendo seu trabalho e preservando sua reputação.', NULL, NULL, NULL, NULL, 36, 85, NULL),
('Procura o seu colega para analisar em conjunto a origem dos problemas e propor uma solução a ser seguida.', NULL, NULL, NULL, NULL, 36, 86, NULL),
('Revê as instruções do projeto e aguarda a reunião para discutir com o seu colega e com o supervisor um plano de ação para atender ao prazo acordado.', NULL, NULL, NULL, NULL, 36, 87, NULL),
('Conversa com seu colega para preparar em conjunto uma lista de todos os erros do projeto para que o seu supervisor decida a melhor forma de agir.', NULL, NULL, NULL, NULL, 36, 88, NULL),
('Pede ajuda a um colega de trabalho mais experiente para que ele converse com o seu supervisor.', NULL, NULL, NULL, NULL, 37, 89, NULL),
('Solicita uma reunião com o seu supervisor para discutir e validar as ideias propostas.', NULL, NULL, NULL, NULL, 37, 90, NULL),
('Envia um e-mail ao seu supervisor, com cópia para o seu diretor, cobrando um retorno sobre as ideias apresentadas.', NULL, NULL, NULL, NULL, 37, 91, NULL),
('Aguarda a resposta do seu supervisor enquanto trabalha em outras atividades relacionadas ao evento.', NULL, NULL, NULL, NULL, 37, 92, NULL),
('Aceita a metodologia proposta para evitar problemas de relacionamento. Afinal, ele parece ter experiência na área.', NULL, NULL, NULL, NULL, 38, 93, NULL),
('Sugere que cada um apresente suas percepções e propostas para avaliação em conjunto da melhor metodologia a ser seguida por todos.', NULL, NULL, NULL, NULL, 38, 94, NULL),
('Com base em sua opinião, propõe uma metodologia alternativa e solicita ao grupo discuta e escolha entre as duas propostas.', NULL, NULL, NULL, NULL, 38, 95, NULL),
('Posiciona-se contra a adoção desta metodologia e leva a situação ao supervisor para definição da melhor forma de trabalho.', NULL, NULL, NULL, NULL, 38, 96, NULL),
('Solicita à área de recursos humanos um treinamento para melhorar sua assertividade durante as reuniões.', NULL, NULL, NULL, NULL, 39, 97, NULL),
('Entende que as reuniões nesta nova área sempre ocorreram desta forma e aceita este modelo de comunicação.', NULL, NULL, NULL, NULL, 39, 98, NULL),
('Solicita um feedback ao seu supervisor, mas também sugere que ele estabeleça regras durante as discussões e debates para tornar os encontros mais produtivos.', NULL, NULL, NULL, NULL, 39, 99, NULL),
('Conversa com os colegas mais próximos para explicar como você se sente e ouvir sugestões de como agir nas reuniões.', NULL, NULL, NULL, NULL, 39, 100, NULL),
('Conversa com outros colegas para tentar descobrir a razão deste comportamento.', NULL, NULL, NULL, NULL, 40, 101, NULL),
('Discute a questão com o seu supervisor, demonstrando a sua insatisfação com o que está acontecendo.', NULL, NULL, NULL, NULL, 40, 102, NULL),
('Aguarda mais alguns dias para ver o que vai acontecer. Afinal, você não fez nada de errado.', NULL, NULL, NULL, NULL, 40, 103, NULL),
('Para evitar polêmicas, encerra o assunto dizendo que a atmosfera do grupo é boa.', NULL, NULL, NULL, NULL, 41, 104, NULL),
('Para o seu próprio bem, diz o que os outros colegas pensam dele.', NULL, NULL, NULL, NULL, 41, 105, NULL),
('Diz a ele, em particular, o que você acredita ser a fonte do problema, exemplificando algumas situações.', NULL, NULL, NULL, NULL, 41, 106, NULL),
('Fala que, em sua opinião, o motivo do clima hostil é o comportamento dele com as pessoas.', NULL, NULL, NULL, NULL, 41, 107, NULL),
('Conversa com seu orientador, explica a situação e solicita que ele ajuste suas atividades para que você possa continuar auxiliando o novo colega sem comprometer suas entregas.', NULL, NULL, NULL, NULL, 42, 108, NULL),
('Informa ao seu novo colega que você precisa focar nas suas atividades atrasadas e, caso sobre tempo, voltará a apoiá-lo.', NULL, NULL, NULL, NULL, 42, 109, NULL),
(' Conversa com os demais bolsistas envolvidos no projeto e justifica o atraso na conclusão de algumas atividades em função da solicitação do orientador para que auxiliasse o novo membro do grupo.', NULL, NULL, NULL, NULL, 42, 110, NULL),
(' Busca o suporte de um colega para concluir algumas atividades menos importantes.', NULL, NULL, NULL, NULL, 42, 111, NULL),
('Tenta rever o planejamento de suas atividades para conclusão do projeto e agenda uma reunião com alguns colegas para compartilhar informações e apresentar suas ideias juntos.', NULL, NULL, NULL, NULL, 43, 112, NULL),
('Como a solicitação foi feita em cima da hora, foca em atender ao prazo de entrega do projeto e deixa para participar da próxima iniciativa de melhorias, caso não esteja tão ocupado.', NULL, NULL, NULL, NULL, 43, 113, NULL),
('Dedica-se o máximo que puder ao projeto e, no tempo restante, prepara uma versão preliminar para melhoria dos processos, para posterior complementação.', NULL, NULL, NULL, NULL, 43, 114, NULL),
('Como aprimorar os processos é importante, requisita a extensão do prazo ao seu supervisor, a fim de que toda a equipe possa contribuir e beneficiar-se dos feedbacks.', NULL, NULL, NULL, NULL, 43, 115, NULL),
('Aceita a oportunidade independente dos comentários sobre o Diretor. É seu papel se adaptar às novas responsabilidades.', NULL, NULL, NULL, NULL, 44, 116, NULL),
('Você educadamente recusa a proposta, já que não quer trabalhar com uma pessoa difícil e que pode prejudicar o seu desempenho.', NULL, NULL, NULL, NULL, 44, 117, NULL),
('Você pede alguns dias para avaliar e procura obter com o seu colega mais detalhes sobre as dificuldades que ele enfrentava com o Diretor.', NULL, NULL, NULL, NULL, 44, 118, NULL),
('Aceita o cargo, mas conversa com o Diretor para definir o relacionamento de trabalho e alinhar as expectativas de ambas as partes.', NULL, NULL, NULL, NULL, 44, 119, NULL),
('Discorda prontamente da avaliação, deixando claro que precisa de tempo para analisar as atividades solicitadas já que, muitas vezes, as orientações são confusas e incompletas.', NULL, NULL, NULL, NULL, 45, 120, NULL),
('Ouve com interesse, solicita exemplos de situações que levaram a esta percepção, para que você possa avaliar como melhorar, mas pontua sobre sua preocupação com a qualidade dos projetos dos clientes.', NULL, NULL, NULL, NULL, 45, 121, NULL),
('Como seu Diretor é mais experiente, aceita o feedback e reduz o tempo de análise para tomada de decisão, mesmo que isso impacte na qualidade das tarefas.', NULL, NULL, NULL, NULL, 45, 122, NULL),
('Mantém sua forma de trabalhar e de tomar decisões e dedica mais horas à Empresa Júnior para lidar com as novas atividades.', NULL, NULL, NULL, NULL, 45, 123, NULL),
('Confia na decisão tomada pelo novo presidente e aguarda a implementação do sistema para emitir sua opinião.', NULL, NULL, NULL, NULL, 46, 124, NULL),
('Busca mais informações sobre o novo sistema e se coloca à disposição para participar da sua implementação.', NULL, NULL, NULL, NULL, 46, 125, NULL),
('Divide suas preocupações com a presidência, explica a importância dos seus projetos atuais e pede para só utilizar o sistema após testes em outros projetos.', NULL, NULL, NULL, NULL, 46, 126, NULL),
('Utiliza sua experiência para antecipar e limitar os possíveis atrasos em seus projetos.', NULL, NULL, NULL, NULL, 46, 127, NULL),
('Durante as reuniões, você decide mostrar ligeiros sinais de impaciência com discussões improdutivas, tentando sensibilizar seu supervisor e demais participantes.', NULL, NULL, NULL, NULL, 47, 128, NULL),
('Leva algum trabalho que possa fazer durante a reunião, sem atrapalhar os demais, para otimizar o seu tempo.', NULL, NULL, NULL, NULL, 47, 129, NULL),
('Divide a questão com o seu supervisor, exemplificando com fatos sua percepção e sugere melhorias para tornar as reuniões mais produtivas.', NULL, NULL, NULL, NULL, 47, 130, NULL),
('Conversa com colegas mais experientes para que eles levem a questão ao supervisor.', NULL, NULL, NULL, NULL, 47, 131, NULL),
('Não faz nada, já que o seu colega é muito próximo do professor orientador e você não quer criar nenhuma inimizade.', NULL, NULL, NULL, NULL, 50, 138, NULL),
('Conversa com seu colega, explica os impactos no projeto e solicita que ele altere seu comportamento.', NULL, NULL, NULL, NULL, 50, 139, NULL),
('Pede para outra pessoa do laboratório, mais próxima do seu colega, conversar com ele para entender o que está ocorrendo.', NULL, NULL, NULL, NULL, 50, 140, NULL),
('Procura o professor orientador e informa o que está acontecendo, para que ele encontre uma solução.', NULL, NULL, NULL, NULL, 50, 141, NULL),
('Informa por e-mail ao Presidente do Diretório Acadêmico que estará ausente pelos próximos 5 dias e se dedica exclusivamente à conclusão do trabalho final.', NULL, NULL, NULL, NULL, 51, 142, NULL),
('Deixa sua caixa de e-mail aberta, enquanto se dedica ao trabalho final. Lê as mensagens associadas ao projeto do Diretório Acadêmico, de acordo com a ordem de entrada em sua caixa, resolvendo os assuntos, quando necessário.', NULL, NULL, NULL, NULL, 51, 143, NULL),
('Deixa sua caixa de e-mail aberta enquanto se dedica ao trabalho final. Responde somente e-mails recebidos do Presidente do Diretório Acadêmico.', NULL, NULL, NULL, NULL, 51, 144, NULL),
('Dedica-se ao trabalho final, mas planeja dois períodos de 30 minutos por dia (manhã e tarde) para avaliar os e-mails associados ao projeto do Diretório Acadêmico e priorizá-los.', NULL, NULL, NULL, NULL, 51, 145, NULL),
('Envia um e-mail para o seu supervisor explicando o ocorrido e aguarda suas orientações.', NULL, NULL, NULL, NULL, 52, 146, NULL),
('Envia imediatamente um e-mail para a pessoa da outra área, copiando os demais envolvidos, pedindo que o relatório seja deletado.', NULL, NULL, NULL, NULL, 52, 147, NULL),
('Vai diretamente à mesa da pessoa que não deveria receber o e-mail, explica as normas  e garante que o relatório seja deletado. Depois disso, você informa ao seu supervisor o ocorrido.', NULL, NULL, NULL, NULL, 52, 148, NULL),
('Não faz nada. Afinal, a solicitação de envio do relatório para todas as pessoas copiadas foi feita pelo seu supervisor.', NULL, NULL, NULL, NULL, 52, 149, NULL),
('Continua a realizar suas atividades da melhor forma possível e solicita o apoio de um colega experiente para revisar o trabalho antes de entregá-lo.', NULL, NULL, NULL, NULL, 53, 150, NULL),
('Esforça-se para adquirir por conta própria o conhecimento técnico necessário, enquanto busca entregar as atividades solicitadas da melhor forma possível.', NULL, NULL, NULL, NULL, 53, 151, NULL),
('Conversa com o líder de projeto, sugere que outra pessoa mais experiente complete as tarefas e pede para que ele lhe dê atividades mais compatíveis com o seu nível de conhecimento.', NULL, NULL, NULL, NULL, 53, 152, NULL),
('Mapeia as principais lacunas de conhecimento e conversa com o líder do projeto sobre suas preocupações, propondo um plano de treinamento rápido para que você consiga adquirir o conhecimento necessário.', NULL, NULL, NULL, NULL, 53, 153, NULL),
('Orienta o seu colega a estruturar um roteiro da apresentação e solicita que ele liste todas as dúvidas que tiver ao longo do trabalho. Na terça-feira, esclarece as e revisa os pontos mais importantes, deixando tempo suficiente para focar na demanda do seu gerente.', NULL, NULL, NULL, NULL, 54, 154, NULL),
('Explica a situação ao seu colega e leva o caso ao supervisor para que este o oriente em relação à priorização das atividades.', NULL, NULL, NULL, NULL, 54, 155, NULL),
('Informa ao seu colega que necessita focar nas demandas urgentes do seu gerente. Aconselha-o a tentar completar o arquivo e se compromete a revisá-lo, caso tenha tempo.', NULL, NULL, NULL, NULL, 54, 156, NULL),
('Explica a situação para seu colega e sugere que ele solicite ao supervisor o apoio de uma outra pessoa para elaborar a apresentação.', NULL, NULL, NULL, NULL, 54, 157, NULL),
('Pergunta para outros colegas mais próximos se eles sabem quem pode lhe auxiliar para completar a tarefa, já que você não quer se expor ou incomodar o seu supervisor.', NULL, NULL, NULL, NULL, 55, 158, NULL),
('Mapeia as principais dúvidas e solicita uma reunião rápida com o seu supervisor para esclarecê-las, certificando-se de que seu trabalho será feito de forma correta.', NULL, NULL, NULL, NULL, 55, 159, NULL),
('Evita incomodar o seu supervisor e completa as etapas cujas informações estão claras nas suas anotações.', NULL, NULL, NULL, NULL, 55, 160, NULL),
('Procura um colega mais experiente e explica a situação para obter conselhos sobre como agir ou as respostas para as suas dúvidas.', NULL, NULL, NULL, NULL, 55, 161, NULL),
('Diz para o consultor o quanto está decepcionado com a sua performance e passa a acompanhar de perto a evolução do trabalho.', NULL, NULL, NULL, NULL, 56, 162, NULL),
('Conversa com o consultor, exemplificando algumas situações em que o comportamento dele não foi adequado e mostra o impacto no projeto. Tenta entender as razões de sua mudança de atitude.', NULL, NULL, NULL, NULL, 56, 163, NULL),
('Reúne a equipe e procura entender o nível de motivação e o interesse no trabalho de cada membro.', NULL, NULL, NULL, NULL, 56, 164, NULL),
('Aguarda mais um tempo antes de tomar uma atitude, para ver se o comportamento e a performance  do consultor melhoram, evitando um conflito e o risco de piorar a situação.', NULL, NULL, NULL, NULL, 56, 165, NULL),
('Conversa com seu gerente, explica a situação e solicita que ele ajuste suas atividades para que você possa continuar auxiliando o novo funcionário sem comprometer suas tarefas.', NULL, NULL, NULL, NULL, 57, 166, NULL),
('Informa ao seu colega que você precisa focar nas suas atividades atrasadas e, caso sobre tempo, voltará a apoiá-lo.', NULL, NULL, NULL, NULL, 57, 167, NULL),
('Conversa com os demais colegas de trabalho e justifica o atraso na conclusão de algumas atividades em função da solicitação do seu gerente para que auxiliasse o novo funcionário.', NULL, NULL, NULL, NULL, 57, 168, NULL),
('Busca o suporte de um colega para concluir algumas atividades menos importantes.', NULL, NULL, NULL, NULL, 57, 169, NULL),
('Conversa novamente com o seu gestor e solicita que ele reorganize suas atividades para que você possa participar do treinamento.', NULL, NULL, NULL, NULL, 58, 170, NULL),
('Informa ao seu gestor que você desistiu de participar do treinamento já que somente uma parte do conteúdo está relacionado com seu trabalho atual.', NULL, NULL, NULL, NULL, 58, 171, NULL),
('Explica ao seu gestor os benefícios do treinamento para sua carreira e como você poderá contribuir futuramente para a organização, a partir deste aprendizado, apresentando alternativas para evitar impactos nas suas atividades.', NULL, NULL, NULL, NULL, 58, 172, NULL),
('Confirma com a área de recursos humanos sua participação apenas na etapa do treinamento relacionada com suas atividades atuais de forma a não prejudicar o seu trabalho.', NULL, NULL, NULL, NULL, 58, 173, NULL),
('Informa por e-mail ao líder do projeto da outra área que estará ausente pelos próximos 5 dias e se dedica exclusivamente à conclusão do relatório.', NULL, NULL, NULL, NULL, 59, 174, NULL),
('Deixa sua caixa de e-mail aberta, enquanto se dedica ao relatório. Lê as mensagens associadas ao projeto, de acordo com a ordem de entrada em sua caixa, resolvendo os assuntos, quando necessário.', NULL, NULL, NULL, NULL, 59, 175, NULL),
('Deixa sua caixa de e-mail aberta, enquanto se dedica ao relatório. Responde somente e-mails recebidos do líder do projeto.', NULL, NULL, NULL, NULL, 59, 176, NULL),
('Dedica-se ao relatório, mas planeja dois períodos de 30 minutos por dia (manhã e tarde) para avaliar os e-mails associados ao projeto e priorizá-los.', NULL, NULL, NULL, NULL, 59, 177, NULL),
('Aceita a oportunidade independente dos comentários sobre o Diretor. É seu papel se adaptar às novas responsabilidades.', NULL, NULL, NULL, NULL, 60, 178, NULL),
('Você educadamente recusa a proposta, já que não quer trabalhar com uma pessoa difícil e que pode prejudicar o seu desempenho.', NULL, NULL, NULL, NULL, 60, 179, NULL),
('Você pede alguns dias para avaliar e procura obter com o seu colega mais detalhes sobre as dificuldades que ele enfrentava com o Diretor.', NULL, NULL, NULL, NULL, 60, 180, NULL),
('Aceita o cargo, mas conversa com o Diretor para definir o relacionamento de trabalho e alinhar as expectativas de ambas as partes.', NULL, NULL, NULL, NULL, 60, 181, NULL),
('Confia na decisão tomada pelo novo diretor e aguarda a implementação do sistema para emitir sua opinião.', NULL, NULL, NULL, NULL, 61, 182, NULL),
('Busca mais informações sobre o novo sistema e se coloca à disposição para participar da sua implementação.', NULL, NULL, NULL, NULL, 61, 183, NULL),
('Divide suas preocupações com o diretor, explica a importância dos seus projetos atuais e pede para só utilizar o sistema após testes em outros projetos.', NULL, NULL, NULL, NULL, 61, 184, NULL),
('Utiliza sua experiência para antecipar e limitar os possíveis atrasos em seus projetos.', NULL, NULL, NULL, NULL, 61, 185, NULL),
('Durante as reuniões, você decide mostrar ligeiros sinais de impaciência com discussões improdutivas, tentando sensibilizar seu gerente e demais participantes.', NULL, NULL, NULL, NULL, 62, 186, NULL),
('Leva algum trabalho que possa fazer durante a reunião, sem atrapalhar os demais, para otimizar o seu tempo.', NULL, NULL, NULL, NULL, 62, 187, NULL),
('Divide a questão com o seu gerente, exemplificando com fatos sua percepção e sugere melhorias para tornar as reuniões mais produtivas.', NULL, NULL, NULL, NULL, 62, 188, NULL),
('Conversa com colegas mais experientes para que eles levem a questão ao gerente.', NULL, NULL, NULL, NULL, 62, 189, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `respostas`
--
ALTER TABLE `respostas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Resposta_Pergunta2` (`idPergunta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `respostas`
--
ALTER TABLE `respostas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=190;
--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `respostas`
--
ALTER TABLE `respostas`
  ADD CONSTRAINT `FK_Resposta_Pergunta2` FOREIGN KEY (`idPergunta`) REFERENCES `perguntas` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
