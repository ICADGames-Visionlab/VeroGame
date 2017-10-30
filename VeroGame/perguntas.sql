-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 30-Out-2017 às 16:17
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
-- Estrutura da tabela `perguntas`
--

CREATE TABLE `perguntas` (
  `Cenario` text,
  `Texto` text,
  `TempoFinalizacao` int(11) DEFAULT NULL,
  `ModificarResposta` tinyint(1) DEFAULT NULL,
  `TipoOrdenacao` int(11) DEFAULT NULL,
  `Obrigatorio` tinyint(1) DEFAULT NULL,
  `Ativo` tinyint(1) DEFAULT NULL,
  `Imagem` varchar(100) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `ConsideraRespostaTempoAcabado` tinyint(1) DEFAULT NULL,
  `Tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `perguntas`
--

INSERT INTO `perguntas` (`Cenario`, `Texto`, `TempoFinalizacao`, `ModificarResposta`, `TipoOrdenacao`, `Obrigatorio`, `Ativo`, `Imagem`, `id`, `ConsideraRespostaTempoAcabado`, `Tipo`) VALUES
('', 'Qual a fórmula você colocaria na célula B18 para obter o total vendido pela pessoa selecionada na célula B17, considerando a data inserida na célula B16?', NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, 1),
('', '	Você enviou acidentalmente um e-mail, que contém informações confidenciais sobre projetos, para a pessoa errada na empresa. Seu superior havia solicitado que não compartilhasse estas informações. Diante disso, como você agiria? 	', 90, 0, 2, 1, NULL, '', 18, NULL, 1),
('', '	Você entrou em uma equipe de projeto e, depois de alguns dias, observou que seu conhecimento técnico está abaixo do necessário para o projeto. Os conhecimentos específicos exigidos não lhe são familiares e, com isso, você percebe que será necessário mais tempo para completar o trabalho corretamente. O que você faria nesta situação?	', 90, 0, 3, 1, NULL, '', 19, NULL, 1),
('', '	Você está trabalhando em um projeto e nos últimos dias um colega trabalha em carga horária irregular. Esta carga horária fez com que ele perdesse diversas reuniões, reduzindo sua contribuição no projeto. Com isso, o projeto é interrompido. Seu colega possui mais experiência e familiaridade com a equipe e com seu superior, do que você. Como você reagiria?	', 90, 0, 4, 1, NULL, '', 20, NULL, 1),
('', '	Seu Líder lhe solicitou uma análise que envolve a identificação de correlações de dados financeiros. Com esta análise ele poderá direcionar as recomendações financeiras e criar relatórios. Uma reunião foi agendada para discutir os resultados da análise, porém você considera cedo e solicita mais uma semana para concluir a tarefa. Diante disso, como você agiria?	', 90, 0, 5, 1, NULL, '', 21, NULL, 1),
('', '	Hoje é quarta-feira e seu superior solicitou seu suporte para auxiliar um colega, que possui pouca experiência com um documento. A tarefa deve ser completada até o final do dia de amanhã. Todavia, outro Líder lhe enviou um arquivo que precisa ser finalizado até o final da semana e demora dois dias para ficar pronto. Há algum tempo seu superior lhe informou que qualquer requisição deste time deveria ser tratada como prioridade. Como você agiria nesta situação?	', 90, 0, 6, 1, NULL, '', 22, NULL, 1),
('', '	Há 3 meses você está trabalhando em um projeto com um colega e, recentemente, vocês perceberam que não atenderão os prazos iniciais. Seu Líder agendou uma reunião para discutir a evolução e progresso do projeto e, agora, é necessário definir sua preparação para esta reunião. O que você faria nesta situação?	', 90, 0, 7, 1, NULL, '', 23, NULL, 1),
('', '	Há 1 mês você está realizando análises de dados e, poucos dias antes do prazo final para a conclusão destas, seu Líder lhe informa que uma das hipóteses inicias deve ser alterada. Isto se deve pela mudança na política organizacional e a validade das análises necessita ser mantida. Você percebe que esta mudança tem um impacto em seu trabalho, afetando diretamente suas conclusões. O que você faria nesta situação?	', 90, 0, 8, 1, NULL, '', 24, NULL, 1),
('', '	Seu superior tem notado que o método de trabalho de cada integrante da equipe é diferente. Com isso, ele lhe solicita que defina um padrão de trabalho, o qual será replicado para todo o time. Alguns colegas percebem esta tarefa como negativa, já que suas habilidades podem ser desafiadas. Como você agiria nesta situação?	', 90, 0, 9, 1, NULL, '', 25, NULL, 1),
('', 'Você é um Líder e, mensalmente, sua equipe necessita elaborar relatórios com indicadores econômicos. Este mês a equipe está sob pressão, já que os prazos entre a disponibilidade das informações e a publicação dos resultados é curto e que o relatório deve ser entregue no prazo. Um profissional que entrou na equipe lhe informa que está com dificuldade de controlar  as informações de seu relatório e sente que não atingirá as expectativas quanto à qualidade do trabalho. Como você reagiria?', 90, 0, 10, 1, NULL, '', 26, NULL, 1),
('', '	Você é um Líder de Projetos e selecionou um funcionário, que possui um histórico de boas avaliações na empresa, para um projeto. Com isso, você conta com seu profissionalismo para estimular o projeto. No entanto, após algumas semanas, a performance do profissional caiu bastante, seu envolvimento com o projeto é superficial e ele também denota comportamentos negativos com a equipe. Como você agiria nesta situação?	', 90, 0, 11, 1, NULL, '', 27, NULL, 1),
('', '	Uma pesquisa com funcionários revelou que o nível de estresse na empresa está alto e o nível de motivação baixo. Esta situação está impactando no funcionamento da empresa e aumentando o número de demissões. Seu Chefe de Unidade lhe solicita que monitore a produtividade do time e evite demissões, pois isso prejudicaria o desenvolvimento da empresa. O que você faria nesta situação? 	', 90, 0, 12, 1, NULL, '', 28, NULL, 1),
('', '	Você foi promovido à Líder e uma responsabilidade de sua equipe é preparar relatórios semanais, utilizando dados levantados em estatísticas financeiras, que são gerenciados por outra área na empresa. Após algumas semanas você analisou a produtividade da equipe e concluiu que a metodologia de trabalho para gerar os relatórios semanais é ineficiente. Esta metodologia consome muito tempo da equipe, gerando frustações. Diante disso, como você agiria?	', 90, 0, 13, 1, NULL, '', 29, NULL, 1),
('', '<span style="font-size:14px;"><center><b>Regulamento</b></center></span><br />\r\nBem-vindo ao Jogo de Seleção Virtual da FGV Talentos 2016!<br />\r\n<br />\r\nEste jogo é composto por 12 cenários que simulam situações reais encontradas em um ambiente profissional e avalia atitudes e competências chaves relacionadas a estes cenários.<br />\r\n<br />\r\n<b>Como responder:</b> cada cenário apresenta 4 (quatro) opções de respostas. O participante deve marcar a mais efetiva e a menos efetiva.<br />\r\n<br />\r\n<b>Navegação:</b><br />\r\n<ul>\r\n<li>Todas as perguntas são obrigatórias;</li>\r\n<li>Para validar as respostas assinaladas, é necessário clicar no botão avançar (>);</li>\r\n<li>Ao expirar o tempo de um cenário, sua resposta é considerada incorreta e o jogo moverá automaticamente para o próximo cenário;</li>\r\n<li>Não é permitido retornar ao cenário anterior;</li>\r\n<li>Nunca feche, atualize ou clique no botão “VOLTAR” do seu navegador. Isso pode invalidar sua participação.</li>\r\n<li>Se houver uma queda de conexão, o jogo reiniciará no cenário onde foi interrompido, mas o tempo continuará sendo contabilizado. Procure iniciar o jogo quando estiver em uma conexão de Internet estável.</li>\r\n</ul>\r\n<br />\r\n<b>Limite de tempo:</b> 90 segundos por pergunta;<br />\r\n<br />\r\n<b>Resultados:</b> suas respostas e pontuações serão enviadas para as empresas participantes da FGV Talentos 2016 e poderão ser usadas nos processos seletivos.<br />\r\n<br />\r\n<b>Atenção:</b><br />\r\n<ul>\r\n<li>Você só poderá participar deste jogo uma única vez.</li>\r\n<li>Participe do jogo com honestidade e sem a ajuda de outras pessoas. Suas respostas poderão ser verificadas em etapas posteriores;</li>\r\n<li>Antes de iniciar, recomendamos a leitura do arquivo “ORIENTAÇÕES DO JOGO”.</li>\r\n</ul>\r\n<br />\r\nPara obter uma melhor visualização do jogo, sugerimos utilizar os navegadores Google Chrome ou Internet Explorer. <br />\r\n<br />\r\nPara iniciar agora, marque “aceitar regulamento” e clique em avançar (>).', NULL, 0, 1, 1, NULL, '', 30, NULL, 1),
('', 'Um novo estagiário foi contratado pela sua empresa e trabalhará na mesma área que você. Seu supervisor lhe solicitou que o orientasse por alguns meses nos processos de trabalho. Após quinze dias, como este apoio ocupa boa parte do seu tempo, algumas das suas entregas começam a atrasar. Diante disso, como você reagiria?', 120, 0, NULL, 1, NULL, '', 31, 1, 1),
('', 'Seu supervisor solicitou que você trabalhasse com um colega na elaboração de um relatório. Ele possui bastante conhecimento e experiência no assunto, além de ser muito próximo do seu chefe. No entanto, nas últimas semanas seu colega não tem dedicado muito tempo às atividades. Ele cancelou diversas reuniões agendadas com você e sua contribuição tem diminuído significativamente, prejudicando a conclusão do relatório. Diante disso, como você se comporta?', 120, NULL, NULL, 1, NULL, NULL, 32, 1, 1),
('', 'A área de recursos humanos da empresa em que você estagia está organizando um treinamento de uma semana e você acredita que ele pode ajudar na sua carreira e desenvolvimento profissional. No entanto, parte do conteúdo não é relevante para as suas atividades atuais, mas pode contribuir com seu trabalho no futuro. Você teve uma rápida conversa com o seu supervisor, mas ele ainda não decidiu sobre a sua participação, já que você está apoiando a equipe em diversas atividades. O que você faz?', 120, NULL, NULL, 1, NULL, NULL, 33, 1, 1),
('', 'Você trabalha com outro estagiário em um mesmo ambiente. Durante vários dias ele vem usando o telefone da empresa por longos períodos para ligar para a namorada que está fazendo intercâmbio em outro país. O regulamento interno da empresa proíbe categoricamente o uso de recursos corporativos para fins pessoais. Qual a sua atitude diante desta situação?', 120, NULL, NULL, 1, NULL, NULL, 34, 1, 1),
('', 'Você começou a estagiar recentemente em uma grande empresa junto com outros universitários. Um dos novos contratados é bastante arrogante e acredita ter mais conhecimento que os demais. Em função disso, os outros estagiários têm falado mal dele por trás. Ao final de uma reunião, você está conversando com um colega quando ele se aproxima e fala que tem percebido uma atmosfera fria e hostil do grupo e pede a sua opinião. O que você responde?', 120, 0, NULL, 1, NULL, '', 35, 1, 1),
('', 'Você está trabalhando há três meses com um colega em um projeto. Recentemente, houve alguns atrasos em tarefas que não eram de sua responsabilidade e tudo indica que ele não será entregue na data inicialmente acordada. O seu supervisor solicitou uma reunião com vocês dois para analisar o progresso. Como você se prepara?', 120, NULL, NULL, 1, NULL, NULL, 36, 1, 1),
('', 'Você está auxiliando o seu supervisor na organização de um evento onde o seu diretor fará uma apresentação de resultados. Você enviou um e-mail com algumas ideias para aprovação. De acordo com as regras da empresa, você precisa da validação do seu supervisor para implementá-las. Entretanto, ele está muito ocupado e ainda não conseguiu responder. Como você procede?', 120, NULL, NULL, 1, NULL, NULL, 37, 1, 1),
('', 'Você trabalha em uma equipe com mais três colegas. Seu supervisor solicita que vocês o apoiem na análise de um relatório. Na primeira reunião da equipe, um dos participantes impõe uma metodologia de trabalho argumentando que esta é a melhor abordagem para a avaliação solicitada, sem procurar ouvir a opinião dos demais. Você tem dúvidas se esta é realmente a maneira correta de realizar a análise. Como você reage?', 120, NULL, NULL, 1, NULL, NULL, 38, 1, 1),
('', 'Você começou a trabalhar em uma nova área da sua empresa há poucos meses e tem sentido dificuldade para dar opiniões durante as reuniões semanais. Todos conversam ao mesmo tempo e basta você começar a falar que algum colega lhe interrompe. Suas sugestões e ideias não têm sido levadas em consideração e você não consegue ser assertivo e contribuir efetivamente com o trabalho da equipe. Como você lida com esta situação?', 120, NULL, NULL, 1, NULL, NULL, 39, 1, 1),
('', 'Você está trabalhando em uma mesma empresa que um colega da sua universidade. Nas últimas semanas ele parece estar chateado com você. Aparentemente, esta mudança de comportamento não tem um motivo específico. Como vocês trabalham em uma mesma equipe e se encontram todos os dias, o clima não está bom. Como você se comporta?', 120, 0, NULL, 1, NULL, '', 40, 1, 1),
('', 'Você está fazendo um trabalho em grupo para uma matéria na universidade. Um dos seus colegas é bastante arrogante e acredita ter mais conhecimento que os demais. Em função disso, os outros membros do grupo têm falado mal dele por trás. Ao final de uma aula, você está conversando com um amigo quando ele se aproxima e fala que tem percebido uma atmosfera fria e hostil do grupo e pede a sua opinião. O que você responde?', NULL, NULL, NULL, NULL, NULL, NULL, 41, NULL, 1),
('', 'Um novo bolsista foi contratado para a sua equipe de iniciação científica e trabalhará no mesmo projeto que você. Seu professor orientador lhe solicitou que o apoiasse por alguns meses nos processos de trabalho. Após quinze dias, como este apoio ocupa boa parte do seu tempo, algumas das suas entregas começam a atrasar. Diante disso, como você reage?', NULL, NULL, NULL, NULL, NULL, NULL, 42, NULL, 1),
('', 'O supervisor da sua área solicitou a todos da equipe que contribuíssem até o final desta semana com sugestões para melhorar os processos de trabalho. Você tem algumas ideias, mas precisa de algum tempo para analisá-las e estruturá-las adequadamente. Entretanto, você está sob pressão pelo prazo de entrega de um projeto e não tem certeza de quando conseguirá tempo. Como você age?', NULL, NULL, NULL, NULL, NULL, NULL, 43, NULL, 1),
('', 'Você é trainee na Empresa Júnior da sua universidade e um de seus colegas, que era Coordenador de Projetos, saiu da equipe. Como você vem se destacando nas suas atividades, o Diretor da área lhe oferece o cargo, que envolve mais responsabilidades. Você ouve comentários que seu colega pediu para ser transferido, pois a comunicação com o Diretor era inadequada e prejudicava seu desempenho. Qual a sua decisão?', NULL, NULL, NULL, NULL, NULL, NULL, 44, NULL, 1),
('', 'Você trabalha na Empresa Júnior da sua universidade e participa de projetos em clientes externos. Durante sua avaliação de desempenho, seu Diretor comenta que você precisa reduzir o tempo de análise antes de tomar decisões, a fim de aumentar a produtividade e poder realizar mais atividades. Você não concorda com este feedback. Como você se posiciona?', NULL, NULL, NULL, NULL, NULL, NULL, 45, NULL, 1),
('', 'Você trabalha há quase 2 anos na Empresa Júnior da sua universidade e é um dos membros mais experientes. O novo presidente, recém empossado, comunica a todos que a empresa contratou um sistema de referência para gestão de projetos. Você já vivenciou mudanças similares e sabe que elas podem impactar na qualidade e prazo dos projetos em andamento. O que você faz?', NULL, NULL, NULL, NULL, NULL, NULL, 46, NULL, 1),
('', 'Você é estagiário em uma grande empresa e um novo supervisor assumiu a área na qual você está alocado. Ele manteve a rotina de reuniões da equipe, mas elas estão mais longas e improdutivas. Após 3 meses, você percebe que os resultados da equipe têm piorado e que seus colegas também estão insatisfeitos com a situação? Qual a sua atitude?', NULL, NULL, NULL, NULL, NULL, NULL, 47, NULL, 1),
('', 'Você e um colega estão participando de um projeto de pesquisa em um laboratório da sua universidade. Ele possui bastante conhecimento e experiência no assunto e é muito próximo do professor orientador. No entanto, nas últimas semanas, seu colega não tem dedicado muito tempo às atividades. Ele faltou a diversas reuniões agendadas com você e sua contribuição tem diminuído significativamente, prejudicando o andamento do projeto. Diante disso, como você se comporta?', NULL, NULL, NULL, NULL, NULL, NULL, 50, NULL, 1),
('', 'Você está concluindo um trabalho final para uma matéria da universidade que deve ser entregue em 5 dias. Seu professor olhou o seu esboço e indicou a necessidade de tarefas adicionais. Você tem dúvidas se conseguirá cumprir o prazo. Além disso, você está à frente de um projeto importante do seu Diretório Acadêmico. Como você organiza sua agenda para entregar o trabalho na data estipulada?', NULL, NULL, NULL, NULL, NULL, NULL, 51, NULL, 1),
('', 'Você recebeu um e-mail do seu supervisor solicitando o envio de um relatório confidencial para todas as pessoas copiadas na mensagem. Após responder o e-mail aos envolvidos, você percebe que enviou o relatório para uma pessoa de outra área da empresa que também estava copiada na mensagem original. Segundo as normas internas, ela não estaria autorizada a acessar estas informações. Seu supervisor está inacessível. O que você faz?', NULL, NULL, NULL, NULL, NULL, NULL, 52, NULL, 1),
('', 'Você trabalha na Empresa Júnior da sua universidade, onde tem a oportunidade de realizar projetos em diversas áreas. Após alguns dias trabalhando em uma nova equipe, você percebe que seu conhecimento técnico está abaixo do necessário e que precisará de mais tempo do que o previsto para completar suas atividades. O que você faz nesta situação?', NULL, NULL, NULL, NULL, NULL, NULL, 53, NULL, 1),
('', 'Hoje é segunda-feira. Durante o almoço com o seu supervisor ele lhe solicitou que apoiasse um colega com pouca experiência na elaboração de uma apresentação, que deve ser concluída até amanhã à tarde. Ao iniciar o trabalho, você recebe uma nova atividade, com alta prioridade, do gerente da sua área. Ela demanda 2 dias inteiros para ser concluída e deve ser entregue até quarta-feira. Como você procede?', NULL, NULL, NULL, NULL, NULL, NULL, 54, NULL, 1),
('', 'Seu supervisor informou que está bastante ocupado hoje e lhe passou uma nova atividade, explicando detalhadamente o que precisava ser feito. Você fez diversas anotações e pensou que havia entendido tudo. Ao começar a trabalhar, percebe que algumas de suas anotações não estão claras e não faz ideia como deve proceder em algumas etapas. Como você reage?', NULL, NULL, NULL, NULL, NULL, NULL, 55, NULL, 1),
('', 'Você está liderando o seu primeiro projeto na Empresa Júnior da sua universidade e montou uma equipe com 4 pessoas, sendo 3 trainees, pouco experientes, e um consultor, bastante experiente e com excelentes avaliações em projetos anteriores. Você conta com ele para impulsionar o projeto. No entanto, durante a última semana, a performance deste consultor tem sido baixa e seu comportamento com a equipe negativo. Isso vem impactando o projeto. O que você faz?', NULL, NULL, NULL, NULL, NULL, NULL, 56, NULL, 1),
('', 'Um novo funcionário foi contratado pela sua empresa e trabalhará na mesma área que você. Seu gerente lhe solicitou que o acompanhasse por alguns meses, ensinando suas atividades e principais processos de trabalho. Após 1 mês, como este apoio ocupa boa parte do seu tempo, algumas das suas tarefas começam a atrasar. Diante disso, como você reage?', NULL, NULL, NULL, NULL, NULL, NULL, 57, NULL, 1),
('', 'A área de recursos humanos da empresa em que você trabalha está organizando um treinamento de uma semana e você acredita que ele pode ajudar na sua carreira e desenvolvimento profissional. No entanto, parte do conteúdo não é relevante para as suas atividades atuais, mas pode contribuir com seu trabalho no futuro. Você teve uma rápida conversa com o seu gestor, mas ele ainda não decidiu sobre a sua participação, já que você está envolvido em diversas atividades. O que você faz?', NULL, NULL, NULL, NULL, NULL, NULL, 58, NULL, 1),
('', 'Você está concluindo um importante relatório que deve ser entregue em 5 dias. Seu gestor olhou o seu esboço e indicou a necessidade de tarefas adicionais. Você tem dúvidas se conseguirá cumprir o prazo. Além disso, você está envolvido em um projeto de outra área e possui atividades pendentes. Como você organiza sua agenda para entregar o relatório na data estipulada?', NULL, NULL, NULL, NULL, NULL, NULL, 59, NULL, 1),
('', 'Um dos seus colegas de trabalho, que era Coordenador de Projetos, saiu da equipe. Como você vem se destacando nas suas atividades, o Diretor da área lhe oferece o cargo, que envolve mais responsabilidades. Você ouve comentários que seu colega pediu para ser transferido, pois a comunicação com o Diretor era inadequada e prejudicava seu desempenho. Qual a sua decisão?', NULL, NULL, NULL, NULL, NULL, NULL, 60, NULL, 1),
('', 'Você trabalha há quase 2 anos em uma empresa e é um dos membros mais experientes da sua área. O novo diretor, recém empossado, comunica a todos que a empresa contratou um sistema de referência para gestão de projetos. Você já vivenciou mudanças similares e sabe que elas podem impactar na qualidade e prazo dos projetos em andamento. O que você faz?', NULL, NULL, NULL, NULL, NULL, NULL, 61, NULL, 1),
('', 'Você trabalha em uma grande empresa e um novo gerente assumiu a área na qual você está alocado. Ele manteve a rotina de reuniões da equipe, mas elas estão mais longas e improdutivas. Após 3 meses, você percebe que os resultados da equipe têm piorado e que seus colegas também estão insatisfeitos com a situação. Qual a sua atitude?', NULL, NULL, NULL, NULL, NULL, NULL, 62, NULL, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `perguntas`
--
ALTER TABLE `perguntas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `perguntas`
--
ALTER TABLE `perguntas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
