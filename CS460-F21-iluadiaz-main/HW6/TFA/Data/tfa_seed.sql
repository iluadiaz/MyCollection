INSERT INTO [TrackEvent](Title)
 VALUES 
	('100'),
	('200'),
	('400'),
	('800'),
	('1500'),
	('3000');

INSERT INTO [Location](Title,MeetDate)
 VALUES 
	('West Albany Meet', '2019-04-03'),
	('Independence', '2019-04-10'),
	('Silverton Triple Meet', '2019-04-17'),
	('Dallas Invitational', '2019-04-24'),
	('Central HS', '2019-05-08'),
	('North Salem HS', '2019-05-16'),
	('District Meet', '2019-05-23'),
	('State Track and Field Championships', '2019-05-30'),
	('Silverton Meet', '2020-04-20'),
	('Dallas Invitational', '2020-04-25'),
	('Central HS', '2020-05-06');

INSERT INTO [Classification](Name)
 VALUES 
	('Girls'),
	('Boys');

INSERT INTO [Coach](FullName)
 VALUES 
	('Eli Cirino'),
	('Don Berger'),
	('Kerri Lemerande'),
	('Erik Cross'),
	('Bill Masei');

INSERT INTO [Team](Name,CoachID)
 VALUES 
	('Central HS', 1),
	('North Salem HS', 2),
	('West Albany HS', 3),
	('Silverton HS', 4),
	('Dallas HS', 5);

INSERT INTO [Athlete](FullName,TeamID)
 VALUES 
	('Horacio Howell', 1),
	('Jared Macdonald', 1),
	('Sophia Lewis', 1),
	('Gordon Weeks', 1),
	('Ellis Malone', 1),
	('Carol Dougherty', 1),
	('April Hurst', 1),
	('Buddy Petty', 1),
	('Emilia Gomez', 1),
	('Kurt Nicholson', 2),
	('Mac Lucas', 2),
	('Elba Mullins', 2),
	('Long Hill', 2),
	('Viola Howell', 2),
	('Rory Bruce', 2),
	('Taylor Pugh', 2),
	('Brooke Rasmussen', 2),
	('Lamont Shea', 3),
	('Lorrie Estes', 3),
	('Lynne Stewart', 3),
	('Trent Mora', 3),
	('Willa Bell', 3),
	('Aurelia Sandoval', 3),
	('Tanner Hensley', 3),
	('Miranda Owens', 3),
	('Vinnie Eimhear', 4),
	('Izzy Katinka', 4),
	('Deo Napoleon', 4),
	('Armen Ben', 4),
	('Geoffrey Rayhana', 4),
	('Ursula Aigle', 4),
	('Morten Randy', 4),
	('Shel Vilim', 4),
	('Khalilah Kane', 4),
	('Iwo Indira', 4),
	('Lysimachos Matey', 4),
	('Birger Arkaitz', 4),
	('Jason Donatas', 4),
	('Vincent Yishai', 4),
	('Sokratis Blagorodna', 5),
	('Pio Lakshmi', 5),
	('Kristijan Sophocles', 5),
	('Vedastus Bextiyar', 5),
	('Morgan Braeden', 5),
	('Bahman Hodr', 5),
	('Aldous Sanjay', 5),
	('Kristine Kat', 5),
	('Toni Rafiqa', 5),
	('Lilias Joel', 5),
	('Vesna Elene', 5);

INSERT INTO [RaceResult](Time,AthleteID,ClassificationID,LocationID,EventID)
 VALUES 
	(105.89,1,2,1,3),
	(254.69,1,2,1,4),
	(32.09,1,2,1,2),
	(424.24,2,2,1,5),
	(149.95,2,2,1,4),
	(20.00,2,2,1,1),
	(780.74,3,1,1,6),
	(43.45,3,1,1,2),
	(480.55,3,1,1,5),
	(463.74,4,2,1,5),
	(259.59,4,2,1,4),
	(104.75,4,2,1,3),
	(97.93,5,2,1,3),
	(23.20,5,2,1,1),
	(366.21,5,2,1,5),
	(1060.50,6,1,1,6),
	(25.67,6,1,1,1),
	(293.98,6,1,1,4),
	(25.89,7,1,1,1),
	(509.23,7,1,1,5),
	(152.14,7,1,1,4),
	(27.50,8,2,1,2),
	(14.94,8,2,1,1),
	(104.03,8,2,1,3),
	(1137.65,9,1,1,6),
	(358.53,9,1,1,5),
	(118.92,9,1,1,3),
	(23.07,18,2,1,2),
	(362.66,18,2,1,5),
	(169.89,18,2,1,4),
	(80.92,19,1,1,3),
	(143.81,19,1,1,4),
	(21.07,19,1,1,1),
	(109.05,20,1,1,3),
	(25.37,20,1,1,1),
	(550.03,20,1,1,5),
	(400.97,21,2,1,5),
	(17.80,21,2,1,1),
	(135.34,21,2,1,4),
	(537.20,22,1,1,5),
	(13.54,22,1,1,1),
	(1196.12,22,1,1,6),
	(665.34,23,1,1,6),
	(24.06,23,1,1,1),
	(81.82,23,1,1,3),
	(14.06,24,2,1,1),
	(99.18,24,2,1,3),
	(49.53,24,2,1,2),
	(124.16,25,1,1,3),
	(460.51,25,1,1,5),
	(205.00,25,1,1,4),
	(18.63,1,2,2,1),
	(308.89,1,2,2,5),
	(804.96,1,2,2,6),
	(39.07,2,2,2,2),
	(19.81,2,2,2,1),
	(62.85,2,2,2,3),
	(67.86,3,1,2,3),
	(14.15,3,1,2,1),
	(883.20,3,1,2,6),
	(790.50,4,2,2,6),
	(215.27,4,2,2,4),
	(372.88,4,2,2,5),
	(46.12,5,2,2,2),
	(90.42,5,2,2,3),
	(149.89,5,2,2,4),
	(387.00,6,1,2,5),
	(58.23,6,1,2,2),
	(1411.29,6,1,2,6),
	(458.71,7,1,2,5),
	(37.96,7,1,2,2),
	(67.69,7,1,2,3),
	(23.44,8,2,2,1),
	(242.29,8,2,2,4),
	(808.80,8,2,2,6),
	(393.11,9,1,2,5),
	(741.23,9,1,2,6),
	(136.39,9,1,2,3),
	(224.21,10,2,2,4),
	(20.93,10,2,2,1),
	(755.08,10,2,2,6),
	(17.86,11,2,2,1),
	(583.31,11,2,2,6),
	(208.42,11,2,2,4),
	(52.29,12,1,2,2),
	(19.75,12,1,2,1),
	(107.99,12,1,2,3),
	(326.20,13,2,2,5),
	(24.69,13,2,2,1),
	(48.63,13,2,2,2),
	(236.46,14,1,2,4),
	(1188.71,14,1,2,6),
	(302.14,14,1,2,5),
	(298.51,15,2,2,5),
	(623.74,15,2,2,6),
	(126.08,15,2,2,4),
	(202.70,16,1,2,4),
	(22.71,16,1,2,1),
	(551.58,16,1,2,5),
	(508.86,17,1,2,5),
	(52.31,17,1,2,2),
	(1423.51,17,1,2,6),
	(112.76,1,2,3,3),
	(45.95,1,2,3,2),
	(554.59,1,2,3,6),
	(204.73,2,2,3,4),
	(813.00,2,2,3,6),
	(300.51,2,2,3,5),
	(27.46,3,1,3,1),
	(600.47,3,1,3,5),
	(1264.19,3,1,3,6),
	(757.00,4,2,3,6),
	(127.32,4,2,3,4),
	(20.87,4,2,3,1),
	(13.34,5,2,3,1),
	(728.02,5,2,3,6),
	(221.24,5,2,3,4),
	(14.89,6,1,3,1),
	(109.13,6,1,3,3),
	(47.15,6,1,3,2),
	(91.45,7,1,3,3),
	(373.68,7,1,3,5),
	(1404.27,7,1,3,6),
	(187.78,8,2,3,4),
	(46.82,8,2,3,2),
	(12.00,8,2,3,1),
	(573.93,9,1,3,5),
	(131.97,9,1,3,3),
	(42.95,9,1,3,2),
	(25.20,18,2,3,1),
	(243.81,18,2,3,5),
	(53.52,18,2,3,3),
	(413.87,19,1,3,5),
	(57.75,19,1,3,2),
	(62.02,19,1,3,3),
	(319.50,20,1,3,4),
	(52.92,20,1,3,2),
	(600.54,20,1,3,5),
	(22.57,21,2,3,2),
	(174.63,21,2,3,4),
	(22.29,21,2,3,1),
	(88.35,22,1,3,3),
	(934.38,22,1,3,6),
	(49.47,22,1,3,2),
	(241.00,23,1,3,4),
	(100.84,23,1,3,3),
	(734.09,23,1,3,6),
	(215.01,24,2,3,4),
	(417.08,24,2,3,5),
	(45.85,24,2,3,2),
	(203.60,25,1,3,4),
	(502.02,25,1,3,5),
	(43.38,25,1,3,2),
	(137.40,10,2,3,4),
	(361.25,10,2,3,5),
	(12.41,10,2,3,1),
	(44.31,11,2,3,2),
	(63.92,11,2,3,3),
	(21.20,11,2,3,1),
	(212.05,12,1,3,4),
	(27.09,12,1,3,1),
	(444.89,12,1,3,5),
	(176.83,13,2,3,4),
	(831.55,13,2,3,6),
	(256.28,13,2,3,5),
	(585.67,14,1,3,5),
	(254.84,14,1,3,4),
	(27.74,14,1,3,1),
	(245.21,15,2,3,4),
	(68.03,15,2,3,3),
	(18.17,15,2,3,1),
	(114.62,16,1,3,3),
	(710.08,16,1,3,6),
	(16.22,16,1,3,1),
	(50.93,17,1,3,2),
	(154.77,17,1,3,4),
	(575.55,17,1,3,5),
	(14.04,1,2,4,1),
	(166.41,1,2,4,4),
	(28.54,1,2,4,2),
	(222.34,2,2,4,4),
	(704.84,2,2,4,6),
	(73.21,2,2,4,3),
	(57.64,3,1,4,2),
	(62.20,3,1,4,3),
	(23.57,3,1,4,1),
	(248.49,4,2,4,4),
	(46.54,4,2,4,2),
	(462.83,4,2,4,5),
	(829.60,5,2,4,6),
	(34.18,5,2,4,2),
	(19.67,5,2,4,1),
	(18.82,6,1,4,1),
	(27.84,6,1,4,2),
	(489.39,6,1,4,5),
	(62.09,7,1,4,3),
	(708.68,7,1,4,6),
	(17.28,7,1,4,1),
	(310.98,8,2,4,5),
	(38.40,8,2,4,2),
	(88.08,8,2,4,3),
	(640.99,9,1,4,5),
	(55.81,9,1,4,2),
	(168.71,9,1,4,4),
	(397.31,18,2,4,5),
	(25.07,18,2,4,1),
	(756.99,18,2,4,6),
	(518.86,19,1,4,5),
	(1316.15,19,1,4,6),
	(42.03,19,1,4,2),
	(28.79,20,1,4,2),
	(255.32,20,1,4,4),
	(645.06,20,1,4,6),
	(112.76,21,2,4,3),
	(392.66,21,2,4,5),
	(1026.07,21,2,4,6),
	(51.56,22,1,4,2),
	(178.17,22,1,4,4),
	(637.48,22,1,4,5),
	(21.64,23,1,4,1),
	(118.15,23,1,4,3),
	(1067.23,23,1,4,6),
	(104.32,24,2,4,3),
	(16.99,24,2,4,1),
	(184.16,24,2,4,4),
	(26.85,25,1,4,1),
	(964.05,25,1,4,6),
	(211.28,25,1,4,4),
	(206.53,10,2,4,4),
	(396.07,10,2,4,5),
	(24.35,10,2,4,1),
	(1087.91,11,2,4,6),
	(23.75,11,2,4,1),
	(422.30,11,2,4,5),
	(53.19,12,1,4,2),
	(13.49,12,1,4,1),
	(89.67,12,1,4,3),
	(69.70,13,2,4,3),
	(22.12,13,2,4,1),
	(213.43,13,2,4,4),
	(880.44,14,1,4,6),
	(21.62,14,1,4,1),
	(54.67,14,1,4,2),
	(307.66,15,2,4,5),
	(76.58,15,2,4,3),
	(732.68,15,2,4,6),
	(170.12,16,1,4,4),
	(31.18,16,1,4,2),
	(27.99,16,1,4,1),
	(530.00,17,1,4,5),
	(31.94,17,1,4,2),
	(279.03,17,1,4,4),
	(33.92,1,2,5,2),
	(13.42,1,2,5,1),
	(146.47,1,2,5,4),
	(158.48,2,2,5,4),
	(16.45,2,2,5,1),
	(399.84,2,2,5,5),
	(209.33,3,1,5,4),
	(21.52,3,1,5,1),
	(1140.24,3,1,5,6),
	(250.44,4,2,5,4),
	(1037.79,4,2,5,6),
	(97.96,4,2,5,3),
	(560.83,5,2,5,6),
	(104.95,5,2,5,3),
	(347.42,5,2,5,5),
	(265.72,6,1,5,4),
	(725.38,6,1,5,6),
	(15.54,6,1,5,1),
	(184.91,7,1,5,4),
	(114.78,7,1,5,3),
	(36.92,7,1,5,2),
	(249.46,8,2,5,4),
	(90.55,8,2,5,3),
	(12.41,8,2,5,1),
	(649.89,9,1,5,6),
	(23.91,9,1,5,1),
	(91.76,9,1,5,3),
	(373.48,18,2,5,5),
	(712.19,18,2,5,6),
	(22.25,18,2,5,1),
	(185.16,19,1,5,4),
	(68.78,19,1,5,3),
	(14.17,19,1,5,1),
	(17.87,20,1,5,1),
	(67.48,20,1,5,3),
	(571.25,20,1,5,5),
	(39.33,21,2,5,2),
	(15.01,21,2,5,1),
	(86.98,21,2,5,3),
	(865.00,22,1,5,6),
	(426.68,22,1,5,5),
	(27.09,22,1,5,1),
	(1087.27,23,1,5,6),
	(250.20,23,1,5,4),
	(457.26,23,1,5,5),
	(77.60,24,2,5,3),
	(815.55,24,2,5,6),
	(24.29,24,2,5,2),
	(465.56,25,1,5,5),
	(62.25,25,1,5,3),
	(1230.30,25,1,5,6),
	(12.57,10,2,6,1),
	(158.94,10,2,6,4),
	(803.63,10,2,6,6),
	(76.76,11,2,6,3),
	(1133.54,11,2,6,6),
	(13.58,11,2,6,1),
	(1028.16,12,1,6,6),
	(226.59,12,1,6,4),
	(51.31,12,1,6,2),
	(135.67,13,2,6,4),
	(1139.74,13,2,6,6),
	(96.84,13,2,6,3),
	(294.57,14,1,6,4),
	(116.03,14,1,6,3),
	(325.61,14,1,6,5),
	(67.23,15,2,6,3),
	(279.45,15,2,6,5),
	(787.85,15,2,6,6),
	(118.38,16,1,6,3),
	(15.47,16,1,6,1),
	(767.63,16,1,6,6),
	(24.50,17,1,6,1),
	(516.04,17,1,6,5),
	(116.59,17,1,6,3),
	(83.84,1,2,6,3),
	(16.42,1,2,6,1),
	(32.82,1,2,6,2),
	(1106.34,2,2,6,6),
	(196.40,2,2,6,4),
	(16.06,2,2,6,1),
	(911.46,3,1,6,6),
	(460.81,3,1,6,5),
	(240.68,3,1,6,4),
	(22.41,4,2,6,1),
	(342.13,4,2,6,5),
	(1112.89,4,2,6,6),
	(1153.90,5,2,6,6),
	(85.98,5,2,6,3),
	(22.74,5,2,6,1),
	(678.45,6,1,6,6),
	(23.21,6,1,6,1),
	(275.83,6,1,6,4),
	(29.61,7,1,6,2),
	(571.16,7,1,6,5),
	(1313.92,7,1,6,6),
	(340.57,8,2,6,5),
	(191.75,8,2,6,4),
	(14.10,8,2,6,1),
	(343.04,9,1,6,5),
	(21.40,9,1,6,1),
	(114.15,9,1,6,3),
	(803.07,1,2,7,6),
	(405.73,1,2,7,5),
	(46.55,1,2,7,2),
	(12.46,2,2,7,1),
	(1016.76,2,2,7,6),
	(275.35,2,2,7,5),
	(29.93,3,1,7,2),
	(666.59,3,1,7,6),
	(163.55,3,1,7,4),
	(504.32,4,2,7,5),
	(74.93,4,2,7,3),
	(40.28,4,2,7,2),
	(683.35,5,2,7,6),
	(30.73,5,2,7,2),
	(103.51,5,2,7,3),
	(248.71,6,1,7,4),
	(26.94,6,1,7,1),
	(47.79,6,1,7,2),
	(1313.02,7,1,7,6),
	(333.03,7,1,7,5),
	(83.91,7,1,7,3),
	(706.64,8,2,7,6),
	(261.51,8,2,7,5),
	(206.00,8,2,7,4),
	(502.29,9,1,7,5),
	(17.88,9,1,7,1),
	(40.68,9,1,7,2),
	(470.61,18,2,7,5),
	(19.94,18,2,7,1),
	(54.52,18,2,7,3),
	(55.15,19,1,7,2),
	(544.99,19,1,7,5),
	(297.39,19,1,7,4),
	(100.13,20,1,7,3),
	(40.67,20,1,7,2),
	(1333.42,20,1,7,6),
	(202.27,21,2,7,4),
	(314.10,21,2,7,5),
	(24.12,21,2,7,2),
	(204.29,22,1,7,4),
	(17.74,22,1,7,1),
	(337.22,22,1,7,5),
	(1245.35,23,1,7,6),
	(544.38,23,1,7,5),
	(19.69,23,1,7,1),
	(22.12,24,2,7,1),
	(235.37,24,2,7,4),
	(641.88,24,2,7,6),
	(1025.13,25,1,7,6),
	(47.57,25,1,7,2),
	(59.97,25,1,7,3),
	(336.98,10,2,7,5),
	(78.06,10,2,7,3),
	(22.26,10,2,7,1),
	(148.76,11,2,7,4),
	(39.44,11,2,7,2),
	(975.29,11,2,7,6),
	(101.62,12,1,7,3),
	(55.70,12,1,7,2),
	(25.26,12,1,7,1),
	(19.25,13,2,7,1),
	(41.96,13,2,7,2),
	(249.86,13,2,7,4),
	(884.89,14,1,7,6),
	(314.51,14,1,7,5),
	(51.83,14,1,7,2),
	(187.62,15,2,7,4),
	(40.79,15,2,7,2),
	(705.95,15,2,7,6),
	(420.55,16,1,7,5),
	(276.87,16,1,7,4),
	(113.49,16,1,7,3),
	(51.99,17,1,7,2),
	(21.95,17,1,7,1),
	(446.05,17,1,7,5),
	(172.25,1,2,8,4),
	(88.04,1,2,8,3),
	(763.18,1,2,8,6),
	(291.97,2,2,8,5),
	(125.94,2,2,8,4),
	(11.46,2,2,8,1),
	(1040.54,3,1,8,6),
	(64.78,3,1,8,3),
	(599.27,3,1,8,5),
	(198.94,4,2,8,4),
	(95.18,4,2,8,3),
	(253.77,4,2,8,5),
	(88.39,5,2,8,3),
	(13.57,5,2,8,1),
	(39.76,5,2,8,2),
	(18.11,6,1,8,1),
	(261.49,6,1,8,4),
	(40.75,6,1,8,2),
	(169.69,7,1,8,4),
	(44.81,7,1,8,2),
	(360.82,7,1,8,5),
	(36.95,8,2,8,2),
	(362.66,8,2,8,5),
	(17.03,8,2,8,1),
	(74.89,9,1,8,3),
	(336.50,9,1,8,5),
	(49.22,9,1,8,2),
	(13.49,18,2,8,1),
	(816.92,18,2,8,6),
	(478.60,18,2,8,5),
	(226.72,19,1,8,4),
	(361.54,19,1,8,5),
	(12.76,19,1,8,1),
	(285.32,20,1,8,4),
	(41.33,20,1,8,2),
	(87.67,20,1,8,3),
	(11.61,21,2,8,1),
	(56.16,21,2,8,3),
	(39.98,21,2,8,2),
	(23.59,22,1,8,1),
	(500.11,22,1,8,5),
	(186.04,22,1,8,4),
	(1315.16,23,1,8,6),
	(249.63,23,1,8,4),
	(345.32,23,1,8,5),
	(42.03,24,2,8,2),
	(192.52,24,2,8,4),
	(287.20,24,2,8,5),
	(77.45,25,1,8,3),
	(839.13,25,1,8,6),
	(47.59,25,1,8,2),
	(76.66,10,2,8,3),
	(370.61,10,2,8,5),
	(25.07,10,2,8,2),
	(456.53,11,2,8,5),
	(14.37,11,2,8,1),
	(23.68,11,2,8,2),
	(1255.82,12,1,8,6),
	(43.66,12,1,8,2),
	(426.96,12,1,8,5),
	(250.18,13,2,8,4),
	(21.74,13,2,8,1),
	(332.61,13,2,8,5),
	(796.27,14,1,8,6),
	(168.31,14,1,8,4),
	(100.67,14,1,8,3),
	(100.40,15,2,8,3),
	(126.09,15,2,8,4),
	(711.97,15,2,8,6),
	(23.60,16,1,8,1),
	(234.58,16,1,8,4),
	(54.17,16,1,8,2),
	(144.84,17,1,8,4),
	(24.31,17,1,8,1),
	(42.02,17,1,8,2),
	(26.49,26,1,9,2),
	(12.65,26,1,9,1),
	(635.49,26,1,9,6),
	(145.79,27,1,9,4),
	(26.78,27,1,9,2),
	(658.40,27,1,9,6),
	(23.15,28,2,9,2),
	(120.96,28,2,9,4),
	(551.38,28,2,9,6),
	(23.39,29,2,9,2),
	(51.69,29,2,9,3),
	(249.76,29,2,9,5),
	(11.63,30,2,9,1),
	(242.93,30,2,9,5),
	(22.52,30,2,9,2),
	(27.13,31,1,9,2),
	(661.17,31,1,9,6),
	(289.46,31,1,9,5),
	(22.93,32,2,9,2),
	(118.36,32,2,9,4),
	(11.36,32,2,9,1),
	(23.01,33,2,9,2),
	(52.50,33,2,9,3),
	(11.59,33,2,9,1),
	(656.31,34,1,9,6),
	(141.78,34,1,9,4),
	(60.87,34,1,9,3),
	(11.22,35,2,9,1),
	(51.62,35,2,9,3),
	(531.85,35,2,9,6),
	(120.29,36,2,9,4),
	(52.17,36,2,9,3),
	(23.53,36,2,9,2),
	(298.85,37,1,9,5),
	(12.76,37,1,9,1),
	(62.07,37,1,9,3),
	(550.33,38,2,9,6),
	(23.50,38,2,9,2),
	(11.27,38,2,9,1),
	(118.31,39,2,9,4),
	(22.75,39,2,9,2),
	(249.07,39,2,9,5),
	(23.37,40,2,9,2),
	(51.37,40,2,9,3),
	(552.64,40,2,9,6),
	(290.63,41,1,9,5),
	(26.65,41,1,9,2),
	(146.60,41,1,9,4),
	(292.29,42,1,9,5),
	(146.44,42,1,9,4),
	(25.85,42,1,9,2),
	(11.60,43,2,9,1),
	(243.98,43,2,9,5),
	(550.36,43,2,9,6),
	(26.08,44,1,9,2),
	(290.39,44,1,9,5),
	(145.35,44,1,9,4),
	(246.81,45,2,9,5),
	(11.36,45,2,9,1),
	(23.21,45,2,9,2),
	(11.17,46,2,9,1),
	(52.53,46,2,9,3),
	(120.15,46,2,9,4),
	(295.78,47,1,9,5),
	(142.59,47,1,9,4),
	(59.62,47,1,9,3),
	(143.05,48,1,9,4),
	(26.89,48,1,9,2),
	(12.62,48,1,9,1),
	(51.35,49,2,9,3),
	(118.85,49,2,9,4),
	(11.34,49,2,9,1),
	(142.46,50,1,9,4),
	(12.52,50,1,9,1),
	(61.49,50,1,9,3),
	(540.56,40,2,4,6),
	(247.33,40,2,4,5),
	(51.62,40,2,4,3),
	(145.62,41,1,4,4),
	(290.99,41,1,4,5),
	(26.15,41,1,4,2),
	(12.55,42,1,4,1),
	(26.15,42,1,4,2),
	(641.48,42,1,4,6),
	(22.95,43,2,4,2),
	(11.48,43,2,4,1),
	(537.79,43,2,4,6),
	(145.38,44,1,4,4),
	(12.79,44,1,4,1),
	(291.86,44,1,4,5),
	(11.32,45,2,4,1),
	(50.96,45,2,4,3),
	(242.17,45,2,4,5),
	(241.85,46,2,4,5),
	(543.09,46,2,4,6),
	(51.06,46,2,4,3),
	(60.07,47,1,4,3),
	(635.18,47,1,4,6),
	(294.46,47,1,4,5),
	(26.00,48,1,4,2),
	(61.41,48,1,4,3),
	(12.70,48,1,4,1),
	(51.47,49,2,4,3),
	(242.23,49,2,4,5),
	(542.57,49,2,4,6),
	(287.08,50,1,4,5),
	(60.50,50,1,4,3),
	(12.89,50,1,4,1),
	(143.11,26,1,4,4),
	(12.56,26,1,4,1),
	(294.64,26,1,4,5),
	(142.93,27,1,4,4),
	(26.48,27,1,4,2),
	(635.17,27,1,4,6),
	(51.26,28,2,4,3),
	(11.43,28,2,4,1),
	(249.32,28,2,4,5),
	(11.15,29,2,4,1),
	(117.90,29,2,4,4),
	(22.71,29,2,4,2),
	(533.43,30,2,4,6),
	(244.33,30,2,4,5),
	(121.88,30,2,4,4),
	(655.05,31,1,4,6),
	(26.06,31,1,4,2),
	(60.65,31,1,4,3),
	(117.72,32,2,4,4),
	(245.68,32,2,4,5),
	(11.33,32,2,4,1),
	(22.66,33,2,4,2),
	(11.23,33,2,4,1),
	(244.94,33,2,4,5),
	(25.83,34,1,4,2),
	(286.21,34,1,4,5),
	(141.97,34,1,4,4),
	(52.16,35,2,4,3),
	(244.03,35,2,4,5),
	(11.30,35,2,4,1),
	(11.34,36,2,4,1),
	(546.33,36,2,4,6),
	(22.77,36,2,4,2),
	(640.62,37,1,4,6),
	(26.68,37,1,4,2),
	(294.81,37,1,4,5),
	(51.43,38,2,4,3),
	(242.35,38,2,4,5),
	(23.03,38,2,4,2),
	(529.78,39,2,4,6),
	(249.47,39,2,4,5),
	(51.63,39,2,4,3),
	(22.51,40,2,5,2),
	(527.70,40,2,5,6),
	(117.64,40,2,5,4),
	(12.52,41,1,5,1),
	(632.20,41,1,5,6),
	(140.75,41,1,5,4),
	(285.60,42,1,5,5),
	(59.27,42,1,5,3),
	(140.75,42,1,5,4),
	(50.65,43,2,5,3),
	(11.15,43,2,5,1),
	(241.22,43,2,5,5),
	(285.60,44,1,5,5),
	(12.52,44,1,5,1),
	(140.75,44,1,5,4),
	(117.64,45,2,5,4),
	(11.15,45,2,5,1),
	(22.51,45,2,5,2),
	(241.22,46,2,5,5),
	(117.64,46,2,5,4),
	(22.51,46,2,5,2),
	(632.20,47,1,5,6),
	(285.60,47,1,5,5),
	(59.27,47,1,5,3),
	(12.52,48,1,5,1),
	(140.75,48,1,5,4),
	(25.78,48,1,5,2),
	(11.15,49,2,5,1),
	(527.70,49,2,5,6),
	(241.22,49,2,5,5),
	(12.52,50,1,5,1),
	(632.20,50,1,5,6),
	(25.78,50,1,5,2),
	(285.60,26,1,5,5),
	(12.52,26,1,5,1),
	(25.78,26,1,5,2),
	(59.27,27,1,5,3),
	(285.60,27,1,5,5),
	(632.20,27,1,5,6),
	(22.51,28,2,5,2),
	(527.70,28,2,5,6),
	(241.22,28,2,5,5),
	(50.65,29,2,5,3),
	(527.70,29,2,5,6),
	(117.64,29,2,5,4),
	(50.65,30,2,5,3),
	(527.70,30,2,5,6),
	(241.22,30,2,5,5),
	(140.75,31,1,5,4),
	(25.78,31,1,5,2),
	(632.20,31,1,5,6),
	(22.51,32,2,5,2),
	(117.64,32,2,5,4),
	(527.70,32,2,5,6),
	(50.65,33,2,5,3),
	(241.22,33,2,5,5),
	(527.70,33,2,5,6),
	(140.75,34,1,5,4),
	(632.20,34,1,5,6),
	(12.52,34,1,5,1),
	(11.15,35,2,5,1),
	(22.51,35,2,5,2),
	(527.70,35,2,5,6),
	(527.70,36,2,5,6),
	(22.51,36,2,5,2),
	(50.65,36,2,5,3),
	(25.78,37,1,5,2),
	(12.52,37,1,5,1),
	(140.75,37,1,5,4),
	(527.70,38,2,5,6),
	(11.15,38,2,5,1),
	(22.51,38,2,5,2),
	(11.15,39,2,5,1),
	(527.70,39,2,5,6),
	(117.64,39,2,5,4);
