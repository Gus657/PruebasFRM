CREATE DATABASE IF NOT EXISTS seguridad;
USE seguridad;

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `procedimientoLogin` (IN `usuario` VARCHAR(25), IN `clave` VARCHAR(25))  NO SQL
Select tbl_usuario.PK_id_Usuario FROM tbl_usuario where tbl_usuario.PK_id_Usuario = usuario and tbl_usuario.password_usuario = MD5(clave) AND tbl_usuario.estado_usuario=1$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_aplicacion`
--

CREATE TABLE `tbl_aplicacion` (
  `PK_id_aplicacion` int(11) NOT NULL,
  `PK_id_modulo` int(11) NOT NULL,
  `nombre_aplicacion` varchar(45) DEFAULT NULL,
  `descripcion_aplicacion` varchar(200) DEFAULT NULL,
  `estado_aplicacion` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_aplicacion`
--

INSERT INTO `tbl_aplicacion` (`PK_id_aplicacion`, `PK_id_modulo`, `nombre_aplicacion`, `descripcion_aplicacion`, `estado_aplicacion`) VALUES
(1, 1, 'Cuetas', 'askncl', 1),
(5111, 1, 'Mantenimiento de Tipos de cuentas contables', '.', 1),
(5112, 1, 'Cuentas Contables', '.', 1),
(5121, 1, 'Libro Diario', '.', 1),
(5122, 1, 'Libro Mayor', '.', 1),
(5123, 1, 'Balances', '.', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bitacora`
--

CREATE TABLE `tbl_bitacora` (
  `PK_id_bitacora` int(11) NOT NULL,
  `PK_id_usuario` varchar(25) NOT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `host` varchar(45) DEFAULT NULL,
  `ip` varchar(25) DEFAULT NULL,
  `accion` varchar(50) DEFAULT NULL,
  `tabla` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_bitacora`
--

INSERT INTO `tbl_bitacora` (`PK_id_bitacora`, `PK_id_usuario`, `fecha`, `hora`, `host`, `ip`, `accion`, `tabla`) VALUES
(825, 'Gus', '2020-04-26', '02:20:32', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(826, 'Gus', '2020-04-26', '02:20:40', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(827, 'Gus', '2020-04-26', '02:20:40', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(828, 'Gus', '2020-04-26', '02:20:44', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(829, 'Gus', '2020-04-26', '02:21:02', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(830, 'Gus', '2020-04-26', '02:21:14', '657PC', '192.168.1.5', 'Asigno aplicacion: Cuetas a usuario: Gus', 'tbl_usuario_aplicacion'),
(831, 'Gus', '2020-04-26', '02:21:21', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(832, 'Gus', '2020-04-26', '02:21:21', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(833, 'Gus', '2020-04-26', '02:21:23', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(834, 'Gus', '2020-04-26', '02:21:31', '657PC', '192.168.1.5', 'Asigno perfil: Super a usuario: Gus', 'tbl_usuario_perfil'),
(835, 'Gus', '2020-04-26', '02:21:34', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(836, 'Gus', '2020-04-26', '02:21:43', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(837, 'Gus', '2020-04-26', '02:21:43', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(838, 'Gus', '2020-04-26', '02:21:45', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(839, 'Gus', '2020-04-26', '02:21:51', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(840, 'Gus', '2020-04-26', '02:21:51', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(841, 'Gus', '2020-04-26', '02:21:55', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(842, 'Gus', '2020-04-26', '02:22:05', '657PC', '192.168.1.5', 'Asigno permiso: Cuetas a perfil: Super', 'tbl_usuario_aplicacion'),
(843, 'Gus', '2020-04-26', '02:22:33', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(844, 'Gus', '2020-04-26', '02:25:16', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(845, 'Gus', '2020-04-26', '02:25:54', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(846, 'Gus', '2020-04-26', '02:25:54', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(847, 'Gus', '2020-04-26', '02:25:59', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(848, 'Gus', '2020-04-26', '02:26:31', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(849, 'Gus', '2020-04-26', '02:27:21', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(850, 'Gus', '2020-04-26', '02:27:54', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(851, 'Gus', '2020-04-26', '02:28:11', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(852, 'Gus', '2020-04-26', '02:28:26', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(853, 'Gus', '2020-04-26', '02:28:44', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(854, 'Gus', '2020-04-26', '02:32:52', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(855, 'Gus', '2020-04-26', '02:33:02', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(856, 'Gus', '2020-04-26', '02:33:02', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(857, 'Gus', '2020-04-26', '02:33:08', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(858, 'Gus', '2020-04-26', '02:33:20', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(859, 'Gus', '2020-04-26', '02:33:26', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(860, 'Gus', '2020-04-26', '02:33:36', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(861, 'Gus', '2020-04-26', '02:33:43', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(862, 'Gus', '2020-04-26', '02:34:22', '657PC', '192.168.1.5', 'Asigno aplicacion: Mantenimiento de Tipos de cuent', 'tbl_usuario_aplicacion'),
(863, 'Gus', '2020-04-26', '02:34:22', '657PC', '192.168.1.5', 'Asigno aplicacion: Cuentas Contables a usuario: Gu', 'tbl_usuario_aplicacion'),
(864, 'Gus', '2020-04-26', '02:34:22', '657PC', '192.168.1.5', 'Asigno aplicacion: Libro Diario a usuario: Gus', 'tbl_usuario_aplicacion'),
(865, 'Gus', '2020-04-26', '02:34:22', '657PC', '192.168.1.5', 'Asigno aplicacion: Libro Mayor a usuario: Gus', 'tbl_usuario_aplicacion'),
(866, 'Gus', '2020-04-26', '02:34:22', '657PC', '192.168.1.5', 'Asigno aplicacion: Balances a usuario: Gus', 'tbl_usuario_aplicacion'),
(867, 'Gus', '2020-04-26', '02:35:11', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(868, 'Gus', '2020-04-26', '02:35:24', '657PC', '192.168.1.5', 'Asigno aplicacion: Cuentas Contables a usuario: Gu', 'tbl_usuario_aplicacion'),
(869, 'Gus', '2020-04-26', '02:58:31', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(870, 'Gus', '2020-04-26', '02:58:39', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(871, 'Gus', '2020-04-26', '03:11:49', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(872, 'Gus', '2020-04-26', '03:19:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(873, 'Gus', '2020-04-26', '03:22:41', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(874, 'Gus', '2020-04-26', '03:35:41', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(875, 'Gus', '2020-04-26', '08:35:28', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(876, 'Gus', '2020-04-26', '08:37:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(877, 'Gus', '2020-04-26', '08:39:15', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(878, 'Gus', '2020-04-26', '08:41:07', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(879, 'Gus', '2020-04-26', '08:44:09', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(880, 'Gus', '2020-04-26', '08:44:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(881, 'Gus', '2020-04-26', '08:44:28', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(882, 'Gus', '2020-04-26', '08:44:36', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(883, 'Gus', '2020-04-26', '08:49:55', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(884, 'Gus', '2020-04-26', '08:50:00', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(885, 'Gus', '2020-04-26', '08:50:52', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(886, 'Gus', '2020-04-26', '08:52:40', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(887, 'Gus', '2020-04-26', '08:52:45', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(888, 'Gus', '2020-04-26', '08:53:20', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(889, 'Gus', '2020-04-26', '08:53:26', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(890, 'Gus', '2020-04-26', '09:16:52', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(891, 'Gus', '2020-04-26', '09:19:44', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(892, 'Gus', '2020-04-26', '09:39:58', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(900, 'Gus', '2020-04-29', '10:22:41', '657PC', '192.168.1.5', 'Consulto bitacora', 'tbl_bitacora'),
(901, 'Gus', '2020-04-29', '10:48:36', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'clientes'),
(902, 'Gus', '2020-04-29', '10:51:18', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'marcas'),
(903, 'Gus', '2020-04-29', '11:00:06', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'productos'),
(904, 'Gus', '2020-04-29', '11:17:02', '657PC', '192.168.1.5', 'Se actualizó un registro', 'productos'),
(905, 'Gus', '2020-04-29', '11:50:44', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'clientes'),
(906, 'Gus', '2020-04-29', '11:51:04', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'marcas'),
(907, 'Gus', '2020-04-29', '11:51:15', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'Lineas'),
(908, 'Gus', '2020-04-29', '11:51:50', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'productos'),
(909, 'Gus', '2020-05-01', '07:47:12', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(910, 'Gus', '2020-05-01', '07:48:02', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(911, 'Gus', '2020-05-01', '08:20:34', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(912, 'Gus', '2020-05-01', '08:25:46', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(913, 'Gus', '2020-05-01', '08:25:55', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(914, 'Gus', '2020-05-01', '08:35:09', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(915, 'Gus', '2020-05-01', '08:35:30', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(916, 'Gus', '2020-05-01', '08:40:33', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(917, 'Gus', '2020-05-08', '12:58:18', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(918, 'Gus', '2020-05-08', '12:58:24', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(919, 'Gus', '2020-05-10', '01:01:04', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(920, 'Gus', '2020-05-10', '01:01:18', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(921, 'Gus', '2020-05-10', '01:01:29', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(922, 'Gus', '2020-05-10', '01:01:34', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(923, 'Gus', '2020-05-10', '01:03:03', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(924, 'Gus', '2020-05-10', '01:03:50', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(925, 'Gus', '2020-05-10', '01:03:58', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(926, 'Gus', '2020-05-10', '02:01:59', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(927, 'Gus', '2020-05-10', '02:02:03', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(928, 'Gus', '2020-05-10', '02:06:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(929, 'Gus', '2020-05-10', '02:06:24', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(930, 'Gus', '2020-05-10', '02:50:06', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(931, 'Gus', '2020-05-10', '02:50:11', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(932, 'Gus', '2020-05-10', '02:51:26', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(933, 'Gus', '2020-05-10', '02:53:42', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(934, 'Gus', '2020-05-10', '02:53:55', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(935, 'Gus', '2020-05-10', '02:55:16', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(936, 'Gus', '2020-05-10', '02:55:46', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(937, 'Gus', '2020-05-10', '02:55:50', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(938, 'Gus', '2020-05-10', '03:35:58', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(939, 'Gus', '2020-05-10', '03:36:02', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(940, 'Gus', '2020-05-10', '03:39:02', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(941, 'Gus', '2020-05-10', '03:39:07', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(942, 'Gus', '2020-05-10', '03:51:35', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(943, 'Gus', '2020-05-10', '03:52:15', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(944, 'Gus', '2020-05-10', '03:52:19', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(945, 'Gus', '2020-05-10', '03:55:10', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(946, 'Gus', '2020-05-10', '03:56:42', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(947, 'Gus', '2020-05-10', '03:58:47', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(948, 'Gus', '2020-05-10', '03:58:52', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(949, 'Gus', '2020-05-10', '04:00:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(950, 'Gus', '2020-05-10', '04:00:25', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(951, 'Gus', '2020-05-10', '04:01:04', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(952, 'Gus', '2020-05-10', '04:01:10', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(953, 'Gus', '2020-05-10', '04:01:15', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(954, 'Gus', '2020-05-10', '04:01:55', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(955, 'Gus', '2020-05-10', '04:03:04', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(956, 'Gus', '2020-05-10', '04:03:10', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(957, 'Gus', '2020-05-10', '04:03:16', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(958, 'Gus', '2020-05-10', '04:03:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(959, 'Gus', '2020-05-10', '04:03:48', '657PC', '192.168.1.5', 'Modifico un Balance', 'Balances'),
(960, 'Gus', '2020-05-10', '04:04:02', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(961, 'Gus', '2020-05-10', '04:04:05', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(962, 'Gus', '2020-05-10', '04:04:21', '657PC', '192.168.1.5', 'Modifico un libro mayor', 'Libro Mayor'),
(963, 'Gus', '2020-05-10', '04:04:25', '657PC', '192.168.1.5', 'Modifico un libro mayor', 'Libro Mayor'),
(964, 'Gus', '2020-05-10', '04:14:32', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(965, 'Gus', '2020-05-10', '04:14:39', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(966, 'Gus', '2020-05-10', '04:17:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(967, 'Gus', '2020-05-10', '04:17:47', '657PC', '192.168.1.5', 'Modifico un Balance', 'Balances'),
(968, 'Gus', '2020-05-10', '04:18:04', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(969, 'Gus', '2020-05-10', '04:18:06', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(970, 'Gus', '2020-05-10', '04:19:19', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(971, 'Gus', '2020-05-10', '04:21:49', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(972, 'Gus', '2020-05-10', '04:21:57', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(973, 'Gus', '2020-05-10', '04:22:46', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(974, 'Gus', '2020-05-10', '04:25:18', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(975, 'Gus', '2020-05-10', '04:26:41', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(976, 'Gus', '2020-05-10', '04:26:50', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(977, 'Gus', '2020-05-10', '04:27:07', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(978, 'Gus', '2020-05-10', '04:27:24', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(979, 'Gus', '2020-05-10', '04:27:31', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(980, 'Gus', '2020-05-10', '04:27:33', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(981, 'Gus', '2020-05-10', '04:28:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(982, 'Gus', '2020-05-10', '04:28:48', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(983, 'Gus', '2020-05-10', '04:28:50', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(984, 'Gus', '2020-05-10', '04:29:21', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(985, 'Gus', '2020-05-10', '04:29:36', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(986, 'Gus', '2020-05-10', '04:29:39', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(987, 'Gus', '2020-05-10', '04:31:04', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(988, 'Gus', '2020-05-10', '04:31:13', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(989, 'Gus', '2020-05-10', '04:31:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(990, 'Gus', '2020-05-10', '04:31:42', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(991, 'Gus', '2020-05-10', '04:31:44', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(992, 'Gus', '2020-05-10', '04:32:00', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(993, 'Gus', '2020-05-10', '04:32:07', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(994, 'Gus', '2020-05-10', '04:32:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(995, 'Gus', '2020-05-10', '04:33:28', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(996, 'Gus', '2020-05-10', '04:33:31', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(997, 'Gus', '2020-05-10', '04:34:19', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(998, 'Gus', '2020-05-10', '04:34:20', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(999, 'Gus', '2020-05-10', '04:41:36', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1000, 'Gus', '2020-05-10', '04:41:45', '657PC', '192.168.1.5', 'Creo un libro Diario', 'Libro Diario'),
(1001, 'Gus', '2020-05-10', '04:41:47', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1002, 'Gus', '2020-05-10', '04:44:55', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1003, 'Gus', '2020-05-10', '04:47:14', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1004, 'Gus', '2020-05-10', '04:48:26', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1005, 'Gus', '2020-05-10', '04:49:28', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1006, 'Gus', '2020-05-10', '04:50:52', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1007, 'Gus', '2020-05-10', '04:51:48', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1008, 'Gus', '2020-05-10', '04:52:14', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1009, 'Gus', '2020-05-10', '04:52:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1010, 'Gus', '2020-05-10', '04:52:56', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1011, 'Gus', '2020-05-10', '04:52:57', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1012, 'Gus', '2020-05-10', '04:53:27', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1013, 'Gus', '2020-05-10', '04:53:28', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1014, 'Gus', '2020-05-10', '04:54:08', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1015, 'Gus', '2020-05-10', '04:54:11', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1016, 'Gus', '2020-05-10', '04:54:44', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1017, 'Gus', '2020-05-10', '04:54:47', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1018, 'Gus', '2020-05-10', '04:55:04', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1019, 'Gus', '2020-05-10', '04:55:15', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1020, 'Gus', '2020-05-10', '04:55:36', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1021, 'Gus', '2020-05-10', '04:55:55', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1022, 'Gus', '2020-05-10', '05:04:08', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1023, 'Gus', '2020-05-10', '05:04:14', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1024, 'Gus', '2020-05-10', '05:04:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1025, 'Gus', '2020-05-10', '05:04:42', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1026, 'Gus', '2020-05-10', '05:04:44', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1027, 'Gus', '2020-05-10', '05:04:56', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1028, 'Gus', '2020-05-10', '05:04:57', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1029, 'Gus', '2020-05-10', '05:05:39', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1030, 'Gus', '2020-05-10', '05:05:55', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1031, 'Gus', '2020-05-10', '05:06:13', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1032, 'Gus', '2020-05-10', '05:06:15', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1033, 'Gus', '2020-05-10', '05:06:29', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1034, 'Gus', '2020-05-10', '05:06:39', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1035, 'Gus', '2020-05-10', '05:07:07', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1036, 'Gus', '2020-05-10', '05:07:14', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1037, 'Gus', '2020-05-10', '05:07:16', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1038, 'Gus', '2020-05-10', '02:07:08', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1039, 'Gus', '2020-05-10', '02:39:57', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1040, 'Gus', '2020-05-10', '02:41:24', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1041, 'Gus', '2020-05-10', '02:42:02', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1042, 'Gus', '2020-05-10', '02:43:02', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1043, 'Gus', '2020-05-10', '02:43:13', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1044, 'Gus', '2020-05-10', '02:43:21', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(1045, 'Gus', '2020-05-10', '02:44:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1046, 'Gus', '2020-05-10', '02:44:25', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(1047, 'Gus', '2020-05-10', '02:44:30', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(1048, 'Gus', '2020-05-10', '03:15:45', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1049, 'Gus', '2020-05-10', '03:15:53', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1050, 'Gus', '2020-05-10', '03:18:29', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1051, 'Gus', '2020-05-10', '03:18:37', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1052, 'Gus', '2020-05-10', '03:24:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1053, 'Gus', '2020-05-10', '03:24:40', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1054, 'Gus', '2020-05-10', '03:27:48', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1055, 'Gus', '2020-05-10', '03:27:53', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1056, 'Gus', '2020-05-10', '03:30:34', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1057, 'Gus', '2020-05-10', '03:30:38', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1058, 'Gus', '2020-05-10', '03:31:30', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1059, 'Gus', '2020-05-10', '03:31:56', '657PC', '192.168.1.5', 'Exporto un Estado de resultados', 'Estado de Resultados'),
(1060, 'Gus', '2020-05-10', '03:32:32', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1061, 'Gus', '2020-05-10', '03:32:49', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1062, 'Gus', '2020-05-10', '08:07:02', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1063, 'Gus', '2020-05-10', '08:08:54', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1064, 'Gus', '2020-05-10', '08:49:03', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1065, 'Gus', '2020-05-10', '08:54:06', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1066, 'Gus', '2020-05-10', '08:55:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1067, 'Gus', '2020-05-10', '11:45:15', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1068, 'Gus', '2020-05-10', '11:45:23', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1069, 'Gus', '2020-05-10', '11:45:37', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1070, 'Gus', '2020-05-10', '11:47:43', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1071, 'Gus', '2020-05-10', '11:47:50', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1072, 'Gus', '2020-05-10', '11:47:51', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1073, 'Gus', '2020-05-10', '11:48:21', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1074, 'Gus', '2020-05-10', '11:48:22', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1075, 'Gus', '2020-05-10', '11:48:51', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1076, 'Gus', '2020-05-10', '11:48:53', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1077, 'Gus', '2020-05-10', '11:49:04', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1078, 'Gus', '2020-05-10', '11:49:06', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1079, 'Gus', '2020-05-11', '08:55:07', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1080, 'Gus', '2020-05-11', '08:56:29', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1081, 'Gus', '2020-05-11', '11:40:11', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1082, 'Gus', '2020-05-11', '12:04:30', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1083, 'Gus', '2020-05-11', '12:18:09', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1084, 'Gus', '2020-05-11', '12:25:31', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1085, 'Gus', '2020-05-11', '12:27:18', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1086, 'Gus', '2020-05-11', '12:29:27', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1087, 'Gus', '2020-05-11', '12:30:07', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1088, 'Gus', '2020-05-11', '08:03:05', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1089, 'Gus', '2020-05-11', '08:03:27', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'empresas'),
(1090, 'Gus', '2020-05-11', '08:03:34', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'empresas'),
(1091, 'Gus', '2020-05-11', '08:03:39', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'empresas'),
(1092, 'Gus', '2020-05-11', '08:09:04', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1093, 'Gus', '2020-05-11', '08:09:17', '657PC', '192.168.1.5', 'Creo un libro Diario', 'Libro Diario'),
(1094, 'Gus', '2020-05-11', '08:09:26', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1095, 'Gus', '2020-05-11', '08:09:32', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1096, 'Gus', '2020-05-11', '08:10:00', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1097, 'Gus', '2020-05-11', '08:10:13', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1098, 'Gus', '2020-05-11', '08:10:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1099, 'Gus', '2020-05-11', '08:10:47', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1100, 'Gus', '2020-05-11', '08:10:50', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1101, 'Gus', '2020-05-11', '08:11:12', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1102, 'Gus', '2020-05-11', '08:11:14', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1103, 'Gus', '2020-05-11', '08:11:36', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1104, 'Gus', '2020-05-11', '08:11:49', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1105, 'Gus', '2020-05-11', '08:11:53', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1106, 'Gus', '2020-05-11', '08:14:54', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1107, 'Gus', '2020-05-11', '08:15:17', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1108, 'Gus', '2020-05-11', '08:15:27', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1109, 'Gus', '2020-05-11', '08:15:32', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1110, 'Gus', '2020-05-11', '08:20:01', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1111, 'Gus', '2020-05-11', '08:20:09', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1112, 'Gus', '2020-05-11', '08:20:14', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1113, 'Gus', '2020-05-11', '08:20:43', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1114, 'Gus', '2020-05-11', '08:20:45', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1115, 'Gus', '2020-05-11', '08:23:09', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1116, 'Gus', '2020-05-11', '08:23:18', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1117, 'Gus', '2020-05-11', '08:23:21', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1118, 'Gus', '2020-05-11', '08:23:37', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1119, 'Gus', '2020-05-11', '08:23:43', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1120, 'Gus', '2020-05-13', '09:28:24', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1121, 'Gus', '2020-05-13', '09:28:34', '657PC', '192.168.1.5', 'Creo un libro Diario', 'Libro Diario'),
(1122, 'Gus', '2020-05-13', '09:28:35', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1123, 'Gus', '2020-05-13', '09:31:37', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1124, 'Gus', '2020-05-13', '09:33:07', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1125, 'Gus', '2020-05-13', '09:34:44', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1126, 'Gus', '2020-05-13', '09:35:35', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1127, 'Gus', '2020-05-13', '09:36:50', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1128, 'Gus', '2020-05-13', '09:39:40', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1129, 'Gus', '2020-05-13', '09:39:54', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1130, 'Gus', '2020-05-13', '09:39:55', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1131, 'Gus', '2020-05-13', '09:40:11', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1132, 'Gus', '2020-05-13', '09:40:13', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1133, 'Gus', '2020-05-13', '09:41:06', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1134, 'Gus', '2020-05-13', '09:41:08', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1135, 'Gus', '2020-05-13', '09:41:27', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1136, 'Gus', '2020-05-13', '09:41:32', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1137, 'Gus', '2020-05-13', '09:35:13', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1138, 'Gus', '2020-05-15', '08:36:27', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1139, 'Gus', '2020-05-15', '08:37:42', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1140, 'Gus', '2020-05-15', '08:37:49', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1141, 'Gus', '2020-05-15', '08:37:50', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1142, 'Gus', '2020-05-15', '08:38:24', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1143, 'Gus', '2020-05-15', '08:38:26', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1144, 'Gus', '2020-05-15', '08:38:56', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1145, 'Gus', '2020-05-15', '08:38:58', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1146, 'Gus', '2020-05-15', '08:39:18', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1147, 'Gus', '2020-05-15', '08:39:23', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1148, 'Gus', '2020-05-15', '08:54:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1149, 'Gus', '2020-05-15', '08:55:37', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1150, 'Gus', '2020-05-15', '08:56:23', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1151, 'Gus', '2020-05-15', '08:57:09', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1152, 'Gus', '2020-05-15', '08:57:30', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1153, 'Gus', '2020-05-15', '08:59:49', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1154, 'Gus', '2020-05-15', '08:59:56', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1155, 'Gus', '2020-05-15', '08:59:57', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1156, 'Gus', '2020-05-15', '09:00:12', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1157, 'Gus', '2020-05-15', '09:00:13', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1158, 'Gus', '2020-05-15', '09:00:29', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1159, 'Gus', '2020-05-15', '09:01:07', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1160, 'Gus', '2020-05-15', '09:01:15', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1161, 'Gus', '2020-05-15', '09:02:27', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1162, 'Gus', '2020-05-15', '09:03:06', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1163, 'Gus', '2020-05-15', '09:03:08', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1164, 'Gus', '2020-05-15', '09:03:29', '657PC', '192.168.1.5', 'Exporto un Estado de resultados', 'Estado de Resultados'),
(1165, 'Gus', '2020-05-15', '09:03:38', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1166, 'Gus', '2020-05-15', '09:03:42', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1167, 'Gus', '2020-05-15', '09:03:58', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1168, 'Gus', '2020-05-16', '11:10:25', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1169, 'Gus', '2020-05-17', '02:43:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1170, 'Gus', '2020-05-17', '02:43:25', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1171, 'Gus', '2020-05-17', '02:44:38', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1172, 'Gus', '2020-05-17', '02:45:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1173, 'Gus', '2020-05-17', '02:45:22', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1174, 'Gus', '2020-05-17', '02:48:16', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1175, 'Gus', '2020-05-17', '02:52:32', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1176, 'Gus', '2020-05-17', '02:52:43', '657PC', '192.168.1.5', 'Creo un libro Diario', 'Libro Diario'),
(1177, 'Gus', '2020-05-17', '02:52:45', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1178, 'Gus', '2020-05-17', '02:52:52', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1179, 'Gus', '2020-05-17', '02:52:55', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1180, 'Gus', '2020-05-17', '02:53:05', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(1181, 'Gus', '2020-05-17', '02:53:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1182, 'Gus', '2020-05-17', '02:53:20', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1183, 'Gus', '2020-05-17', '02:53:57', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1184, 'Gus', '2020-05-17', '02:54:03', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(1185, 'Gus', '2020-05-17', '02:58:23', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1186, 'Gus', '2020-05-17', '02:58:33', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1187, 'Gus', '2020-05-17', '02:58:51', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1188, 'Gus', '2020-05-17', '03:00:43', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1189, 'Gus', '2020-05-17', '03:00:49', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1190, 'Gus', '2020-05-17', '03:01:09', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1191, 'Gus', '2020-05-17', '03:09:42', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1192, 'Gus', '2020-05-17', '03:09:54', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1193, 'Gus', '2020-05-17', '03:09:56', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1194, 'Gus', '2020-05-17', '03:10:07', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1195, 'Gus', '2020-05-17', '03:10:08', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1196, 'Gus', '2020-05-17', '03:10:08', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1197, 'Gus', '2020-05-17', '03:10:08', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1198, 'Gus', '2020-05-17', '03:10:11', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1199, 'Gus', '2020-05-17', '03:10:11', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1200, 'Gus', '2020-05-17', '03:10:11', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1201, 'Gus', '2020-05-17', '03:10:16', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1202, 'Gus', '2020-05-17', '03:10:16', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1203, 'Gus', '2020-05-17', '03:10:16', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1204, 'Gus', '2020-05-17', '03:10:17', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1205, 'Gus', '2020-05-17', '03:10:17', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1206, 'Gus', '2020-05-17', '03:10:17', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1207, 'Gus', '2020-05-17', '03:10:18', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1208, 'Gus', '2020-05-17', '03:10:18', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1209, 'Gus', '2020-05-17', '03:10:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1210, 'Gus', '2020-05-17', '03:10:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1211, 'Gus', '2020-05-17', '03:10:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1212, 'Gus', '2020-05-17', '03:10:20', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1213, 'Gus', '2020-05-17', '03:10:26', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1214, 'Gus', '2020-05-17', '03:10:41', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1215, 'Gus', '2020-05-17', '03:10:42', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1216, 'Gus', '2020-05-17', '03:10:48', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1217, 'Gus', '2020-05-17', '03:10:54', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1218, 'Gus', '2020-05-17', '03:10:56', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1219, 'Gus', '2020-05-17', '03:10:59', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1220, 'Gus', '2020-05-17', '03:13:08', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1221, 'Gus', '2020-05-17', '03:13:14', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1222, 'Gus', '2020-05-17', '03:13:19', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1223, 'Gus', '2020-05-17', '03:13:34', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1224, 'Gus', '2020-05-17', '03:15:03', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1225, 'Gus', '2020-05-17', '03:15:09', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1226, 'Gus', '2020-05-17', '03:19:10', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1227, 'Gus', '2020-05-17', '03:19:17', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1228, 'Gus', '2020-05-17', '03:19:22', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1229, 'Gus', '2020-05-17', '03:19:23', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1230, 'Gus', '2020-05-17', '03:19:23', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1231, 'Gus', '2020-05-17', '03:19:24', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1232, 'Gus', '2020-05-17', '03:19:42', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1233, 'Gus', '2020-05-17', '03:20:02', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1234, 'Gus', '2020-05-17', '03:23:28', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1235, 'Gus', '2020-05-17', '03:23:35', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1236, 'Gus', '2020-05-17', '03:23:41', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1237, 'Gus', '2020-05-17', '03:23:43', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1238, 'Gus', '2020-05-17', '03:23:48', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1239, 'Gus', '2020-05-17', '03:24:17', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1240, 'Gus', '2020-05-17', '03:24:23', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1241, 'Gus', '2020-05-17', '03:24:28', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1242, 'Gus', '2020-05-17', '03:25:36', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1243, 'Gus', '2020-05-17', '03:25:41', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1244, 'Gus', '2020-05-17', '03:25:50', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1245, 'Gus', '2020-05-17', '03:25:53', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1246, 'Gus', '2020-05-17', '03:26:43', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1247, 'Gus', '2020-05-17', '03:26:49', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1248, 'Gus', '2020-05-17', '03:26:56', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1249, 'Gus', '2020-05-17', '03:27:01', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1250, 'Gus', '2020-05-17', '03:28:34', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1251, 'Gus', '2020-05-17', '03:28:39', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1252, 'Gus', '2020-05-17', '03:28:45', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1253, 'Gus', '2020-05-17', '03:28:53', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1254, 'Gus', '2020-05-17', '03:29:02', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1255, 'Gus', '2020-05-17', '03:31:00', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1256, 'Gus', '2020-05-17', '03:31:04', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1257, 'Gus', '2020-05-17', '03:31:17', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1258, 'Gus', '2020-05-17', '03:31:22', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1259, 'Gus', '2020-05-17', '03:31:29', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1260, 'Gus', '2020-05-17', '03:31:40', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1261, 'Gus', '2020-05-17', '03:32:09', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1262, 'Gus', '2020-05-17', '03:32:15', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1263, 'Gus', '2020-05-17', '03:32:18', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1264, 'Gus', '2020-05-17', '03:33:03', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1265, 'Gus', '2020-05-17', '03:33:07', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1266, 'Gus', '2020-05-17', '03:33:16', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1267, 'Gus', '2020-05-17', '03:33:19', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1268, 'Gus', '2020-05-17', '03:37:55', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1269, 'Gus', '2020-05-17', '03:38:06', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1270, 'Gus', '2020-05-17', '03:38:07', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1271, 'Gus', '2020-05-17', '03:38:18', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1272, 'Gus', '2020-05-17', '03:38:40', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1273, 'Gus', '2020-05-17', '03:38:45', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1274, 'Gus', '2020-05-17', '03:38:54', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1275, 'Gus', '2020-05-17', '03:43:10', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1276, 'Gus', '2020-05-17', '03:43:20', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1277, 'Gus', '2020-05-17', '03:43:21', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1278, 'Gus', '2020-05-17', '03:43:31', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1279, 'Gus', '2020-05-17', '03:43:41', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1280, 'Gus', '2020-05-17', '03:43:46', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1281, 'Gus', '2020-05-17', '03:32:00', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1282, 'Gus', '2020-05-17', '03:44:06', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1283, 'Gus', '2020-05-17', '03:44:48', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1284, 'Gus', '2020-05-17', '03:45:04', '657PC', '192.168.1.5', 'Se creó un nuevo registro', 'tipo_polizas'),
(1285, 'Gus', '2020-05-17', '04:17:32', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1286, 'Gus', '2020-05-17', '04:44:18', '657PC', '192.168.1.5', 'Modifico un libro Diario', 'Libro Diario'),
(1287, 'Gus', '2020-05-17', '04:44:37', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1288, 'Gus', '2020-05-17', '04:47:06', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1289, 'Gus', '2020-05-17', '04:47:12', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1290, 'Gus', '2020-05-17', '04:48:19', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1291, 'Gus', '2020-05-17', '04:48:24', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1292, 'Gus', '2020-05-17', '04:49:05', '657PC', '192.168.1.5', 'Creo una partida', 'Libro Diario'),
(1293, 'Gus', '2020-05-17', '04:50:08', '657PC', '192.168.1.5', 'Elimino una partida', 'Libro Diario'),
(1294, 'Gus', '2020-05-17', '04:50:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1295, 'Gus', '2020-05-17', '04:51:31', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1296, 'Gus', '2020-05-17', '05:24:01', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1297, 'Gus', '2020-05-17', '05:25:42', '657PC', '192.168.1.5', 'Modifico un libro mayor', 'Libro Mayor'),
(1298, 'Gus', '2020-05-17', '05:26:05', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1299, 'Gus', '2020-05-17', '05:27:15', '657PC', '192.168.1.5', 'Creo un libro Mayor', 'Libro Mayor'),
(1300, 'Gus', '2020-05-17', '05:27:16', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1301, 'Gus', '2020-05-17', '05:28:53', '657PC', '192.168.1.5', 'Exporto un libro Diario', 'Libro Diario'),
(1302, 'Gus', '2020-05-17', '05:41:07', '657PC', '192.168.1.5', 'Creo un balance', 'Balances'),
(1303, 'Gus', '2020-05-17', '05:41:55', '657PC', '192.168.1.5', 'Modifico un Balance', 'Balances'),
(1304, 'Gus', '2020-05-17', '05:42:12', '657PC', '192.168.1.5', 'Vio un Balance', 'Balances'),
(1305, 'Gus', '2020-05-17', '05:52:42', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1306, 'Gus', '2020-05-17', '05:53:29', '657PC', '192.168.1.5', 'Modifico un Estado de Resultados', 'Estado de Resultados'),
(1307, 'Gus', '2020-05-17', '05:53:31', '657PC', '192.168.1.5', 'Vio un Estado De Resultados', 'Estado De resultados'),
(1308, 'Gus', '2020-05-17', '05:55:09', '657PC', '192.168.1.5', 'Creo un balance', 'balance-general'),
(1309, 'Gus', '2020-05-17', '05:55:57', '657PC', '192.168.1.5', 'Modifico un Balance', 'balance-general'),
(1310, 'Gus', '2020-05-17', '05:55:58', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1311, 'Gus', '2020-05-17', '06:45:28', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1312, 'Gus', '2020-05-17', '06:48:58', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1313, 'Gus', '2020-05-17', '06:53:26', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1314, 'Gus', '2020-05-17', '06:56:09', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1315, 'Gus', '2020-05-17', '06:56:21', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1316, 'Gus', '2020-05-17', '06:58:01', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1317, 'Gus', '2020-05-17', '07:02:50', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1318, 'Gus', '2020-05-18', '12:29:54', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1319, 'Gus', '2020-05-18', '01:20:55', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1320, 'Gus', '2020-05-18', '01:21:57', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(1321, 'Gus', '2020-05-18', '01:21:57', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1322, 'Gus', '2020-05-18', '01:22:01', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1323, 'Gus', '2020-05-18', '01:22:12', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1324, 'Gus', '2020-05-18', '01:22:17', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1325, 'Gus', '2020-05-18', '01:22:32', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion');
INSERT INTO `tbl_bitacora` (`PK_id_bitacora`, `PK_id_usuario`, `fecha`, `hora`, `host`, `ip`, `accion`, `tabla`) VALUES
(1326, 'Gus', '2020-05-18', '01:22:40', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1327, 'Gus', '2020-05-18', '01:22:47', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1328, 'Gus', '2020-05-18', '01:23:20', '657PC', '192.168.1.5', 'Asigno aplicacion: Cuetas a usuario: test', 'tbl_usuario_aplicacion'),
(1329, 'Gus', '2020-05-18', '01:23:20', '657PC', '192.168.1.5', 'Asigno aplicacion: Mantenimiento de Tipos de cuent', 'tbl_usuario_aplicacion'),
(1330, 'Gus', '2020-05-18', '01:23:20', '657PC', '192.168.1.5', 'Asigno aplicacion: Cuentas Contables a usuario: te', 'tbl_usuario_aplicacion'),
(1331, 'Gus', '2020-05-18', '01:23:20', '657PC', '192.168.1.5', 'Asigno aplicacion: Libro Diario a usuario: test', 'tbl_usuario_aplicacion'),
(1332, 'Gus', '2020-05-18', '01:23:21', '657PC', '192.168.1.5', 'Asigno aplicacion: Libro Mayor a usuario: test', 'tbl_usuario_aplicacion'),
(1333, 'Gus', '2020-05-18', '01:23:21', '657PC', '192.168.1.5', 'Asigno aplicacion: Balances a usuario: test', 'tbl_usuario_aplicacion'),
(1334, 'Gus', '2020-05-18', '01:23:29', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(1335, 'Gus', '2020-05-18', '01:23:29', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(1336, 'Gus', '2020-05-18', '01:23:31', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(1337, 'Gus', '2020-05-18', '01:23:37', '657PC', '192.168.1.5', 'Asigno perfil: Super a usuario: test', 'tbl_usuario_perfil'),
(1338, 'Gus', '2020-05-18', '01:23:41', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(1339, 'Gus', '2020-05-18', '01:23:42', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(1340, 'Gus', '2020-05-18', '01:23:46', '657PC', '192.168.1.5', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(1341, 'Gus', '2020-05-18', '01:23:47', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1342, 'test', '2020-05-18', '01:24:06', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1343, 'test', '2020-05-18', '01:24:28', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(1344, 'test', '2020-05-18', '01:24:28', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1345, 'test', '2020-05-18', '01:25:24', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1346, 'test', '2020-05-18', '01:25:44', '657PC', '192.168.1.5', 'Vio las partidas', 'Libro Diario'),
(1347, 'test', '2020-05-18', '01:25:50', '657PC', '192.168.1.5', 'Consulto bitacora', 'tbl_bitacora'),
(1348, 'test', '2020-05-18', '01:26:11', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(1349, 'test', '2020-05-18', '01:26:11', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1350, 'test', '2020-05-18', '01:26:18', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1351, 'test', '2020-05-18', '01:26:29', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1352, 'test', '2020-05-18', '01:26:54', '657PC', '192.168.1.5', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(1353, 'test', '2020-05-18', '01:26:54', '657PC', '192.168.1.5', 'Realizo una consulta a modulos', 'tbl_modulos'),
(1354, 'test', '2020-05-18', '01:26:57', '657PC', '192.168.1.5', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(1355, 'test', '2020-05-18', '01:27:05', '657PC', '192.168.1.5', 'Asigno aplicacion: Mantenimiento de Tipos de cuent', 'tbl_usuario_aplicacion'),
(1356, 'test', '2020-05-18', '01:29:57', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1357, 'test', '2020-05-18', '01:30:24', '657PC', '192.168.1.5', 'Vio un Balance General', 'balance-general'),
(1358, 'Gus', '2020-05-18', '01:41:56', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1359, 'Gus', '2020-05-18', '01:50:17', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1360, 'test', '2020-05-18', '01:50:46', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1361, 'test', '2020-05-18', '01:50:57', '657PC', '192.168.1.5', 'Se actualizó un registro', 'tipo_cuentas'),
(1362, 'test', '2020-05-18', '01:51:03', '657PC', '192.168.1.5', 'Consulto bitacora', 'tbl_bitacora'),
(1363, 'Gus', '2020-05-18', '01:53:01', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1364, 'Gus', '2020-05-18', '01:53:58', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1365, 'Gus', '2020-05-18', '01:55:05', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1366, 'Gus', '2020-05-18', '01:59:15', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login'),
(1367, 'Gus', '2020-05-18', '02:08:38', '657PC', '192.168.1.5', 'Se logeo al sistema', 'Login');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_modulo`
--

CREATE TABLE `tbl_modulo` (
  `PK_id_Modulo` int(11) NOT NULL,
  `nombre_modulo` varchar(45) DEFAULT NULL,
  `descripcion_modulo` varchar(200) DEFAULT NULL,
  `estado_modulo` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_modulo`
--

INSERT INTO `tbl_modulo` (`PK_id_Modulo`, `nombre_modulo`, `descripcion_modulo`, `estado_modulo`) VALUES
(1, 'FRM', 'Finanzas XD', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_perfil_detalle`
--

CREATE TABLE `tbl_perfil_detalle` (
  `PK_id_perfil` int(11) NOT NULL,
  `PK_id_aplicacion` int(11) NOT NULL,
  `ingresar` tinyint(4) DEFAULT NULL,
  `consultar` tinyint(4) DEFAULT NULL,
  `modificar` tinyint(4) DEFAULT NULL,
  `eliminar` tinyint(4) DEFAULT NULL,
  `imprimir` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_perfil_detalle`
--

INSERT INTO `tbl_perfil_detalle` (`PK_id_perfil`, `PK_id_aplicacion`, `ingresar`, `consultar`, `modificar`, `eliminar`, `imprimir`) VALUES
(1, 1, 1, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_perfil_encabezado`
--

CREATE TABLE `tbl_perfil_encabezado` (
  `PK_id_perfil` int(11) NOT NULL,
  `nombre_perfil` varchar(45) DEFAULT NULL,
  `descripcion_perfil` varchar(200) DEFAULT NULL,
  `estado_perfil` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_perfil_encabezado`
--

INSERT INTO `tbl_perfil_encabezado` (`PK_id_perfil`, `nombre_perfil`, `descripcion_perfil`, `estado_perfil`) VALUES
(1, 'Super', 'XD', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario`
--

CREATE TABLE `tbl_usuario` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `nombre_usuario` varchar(45) DEFAULT NULL,
  `apellido_usuarios` varchar(45) DEFAULT NULL,
  `password_usuario` varchar(45) DEFAULT NULL,
  `cambio_contrasena` tinyint(4) DEFAULT NULL,
  `estado_usuario` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario`
--

INSERT INTO `tbl_usuario` (`PK_id_usuario`, `nombre_usuario`, `apellido_usuarios`, `password_usuario`, `cambio_contrasena`, `estado_usuario`) VALUES
('Gus', 'Gus', '-', 'b4288d9c0ec0a1841b3b3728321e7088', 1, 1),
('test', 'test', 'test', '16d7a4fca7442dda3ad93c9a726597e4', NULL, 1);

--
-- Disparadores `tbl_usuario`
--
DELIMITER $$
CREATE TRIGGER `actualizarClave` BEFORE UPDATE ON `tbl_usuario` FOR EACH ROW IF NEW.password_usuario <> OLD.password_usuario THEN
SET NEW.password_usuario = MD5(NEW.password_usuario);
END IF
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `encriptarClave` BEFORE INSERT ON `tbl_usuario` FOR EACH ROW BEGIN
SET NEW.password_usuario = MD5(NEW.password_usuario);
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario_aplicacion`
--

CREATE TABLE `tbl_usuario_aplicacion` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `PK_id_aplicacion` int(11) NOT NULL,
  `ingresar` tinyint(4) DEFAULT NULL,
  `consultar` tinyint(4) DEFAULT NULL,
  `modificar` tinyint(4) DEFAULT NULL,
  `eliminar` tinyint(4) DEFAULT NULL,
  `imprimir` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario_aplicacion`
--

INSERT INTO `tbl_usuario_aplicacion` (`PK_id_usuario`, `PK_id_aplicacion`, `ingresar`, `consultar`, `modificar`, `eliminar`, `imprimir`) VALUES
('Gus', 5111, 1, 1, 1, 1, 1),
('Gus', 5112, 1, 1, 1, 1, 1),
('Gus', 5121, 1, 1, 1, 1, 1),
('Gus', 5122, 1, 1, 1, 1, 1),
('Gus', 5123, 1, 1, 1, 1, 1),
('test', 5111, 1, 1, 1, 1, 1),
('test', 5112, 1, 1, 1, 1, 1),
('test', 5121, 1, 1, 1, 1, 1),
('test', 5122, 1, 1, 1, 1, 1),
('test', 5123, 1, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario_perfil`
--

CREATE TABLE `tbl_usuario_perfil` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `PK_id_perfil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario_perfil`
--

INSERT INTO `tbl_usuario_perfil` (`PK_id_usuario`, `PK_id_perfil`) VALUES
('Gus', 1),
('test', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD PRIMARY KEY (`PK_id_aplicacion`,`PK_id_modulo`),
  ADD KEY `fk_Aplicacion_Modulo` (`PK_id_modulo`);

--
-- Indices de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD PRIMARY KEY (`PK_id_bitacora`,`PK_id_usuario`),
  ADD KEY `fk_Bitacora_Usuario1` (`PK_id_usuario`);

--
-- Indices de la tabla `tbl_modulo`
--
ALTER TABLE `tbl_modulo`
  ADD PRIMARY KEY (`PK_id_Modulo`);

--
-- Indices de la tabla `tbl_perfil_detalle`
--
ALTER TABLE `tbl_perfil_detalle`
  ADD PRIMARY KEY (`PK_id_perfil`,`PK_id_aplicacion`),
  ADD KEY `fk_Perfil_detalle_Aplicacion1` (`PK_id_aplicacion`);

--
-- Indices de la tabla `tbl_perfil_encabezado`
--
ALTER TABLE `tbl_perfil_encabezado`
  ADD PRIMARY KEY (`PK_id_perfil`);

--
-- Indices de la tabla `tbl_usuario`
--
ALTER TABLE `tbl_usuario`
  ADD PRIMARY KEY (`PK_id_usuario`);

--
-- Indices de la tabla `tbl_usuario_aplicacion`
--
ALTER TABLE `tbl_usuario_aplicacion`
  ADD PRIMARY KEY (`PK_id_usuario`,`PK_id_aplicacion`),
  ADD KEY `fk_tbl_usuario_aplicacion_tbl_aplicacion1` (`PK_id_aplicacion`);

--
-- Indices de la tabla `tbl_usuario_perfil`
--
ALTER TABLE `tbl_usuario_perfil`
  ADD PRIMARY KEY (`PK_id_usuario`,`PK_id_perfil`),
  ADD KEY `fk_Usuario_perfil_Perfil1` (`PK_id_perfil`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  MODIFY `PK_id_bitacora` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1368;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD CONSTRAINT `fk_Aplicacion_Modulo` FOREIGN KEY (`PK_id_modulo`) REFERENCES `tbl_modulo` (`PK_id_Modulo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD CONSTRAINT `fk_Bitacora_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_perfil_detalle`
--
ALTER TABLE `tbl_perfil_detalle`
  ADD CONSTRAINT `fk_Perfil_detalle_Aplicacion1` FOREIGN KEY (`PK_id_aplicacion`) REFERENCES `tbl_aplicacion` (`PK_id_aplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Perfil_detalle_Perfil1` FOREIGN KEY (`PK_id_perfil`) REFERENCES `tbl_perfil_encabezado` (`PK_id_perfil`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_usuario_aplicacion`
--
ALTER TABLE `tbl_usuario_aplicacion`
  ADD CONSTRAINT `fk_Usuario_aplicacion_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_usuario_aplicacion_tbl_aplicacion1` FOREIGN KEY (`PK_id_aplicacion`) REFERENCES `tbl_aplicacion` (`PK_id_aplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_usuario_perfil`
--
ALTER TABLE `tbl_usuario_perfil`
  ADD CONSTRAINT `fk_Usuario_perfil_Perfil1` FOREIGN KEY (`PK_id_perfil`) REFERENCES `tbl_perfil_encabezado` (`PK_id_perfil`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Usuario_perfil_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;


