CREATE DATABASE IF NOT EXISTS frm;
USE frm;

CREATE TABLE `ayuda` (
  `Id_ayuda` int(11) NOT NULL,
  `Ruta` text COLLATE utf8_unicode_ci NOT NULL,
  `indice` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `ayuda`
--

INSERT INTO `ayuda` (`Id_ayuda`, `Ruta`, `indice`) VALUES
(1, 'Página web ayuda/ayuda.chm', 'menu.html'),
(2, 'Página web ayuda/ayuda.chm', 'Menúboletos.html');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `balances`
--

CREATE TABLE `balances` (
  `id_balance` int(11) NOT NULL,
  `id_libro_mayor` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `estado` tinyint(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `balances`
--

INSERT INTO `balances` (`id_balance`, `id_libro_mayor`, `fecha`, `estado`) VALUES
(1, 1, '2020-05-18', 1),
(2, 2, '2020-05-18', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `balances_detalles`
--

CREATE TABLE `balances_detalles` (
  `numero` int(11) NOT NULL,
  `id_balance` int(11) NOT NULL,
  `cuenta_contable` varchar(250) NOT NULL,
  `debe` float NOT NULL DEFAULT '0',
  `haber` float NOT NULL DEFAULT '0',
  `deudor` float NOT NULL DEFAULT '0',
  `acreedor` float NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `balances_detalles`
--

INSERT INTO `balances_detalles` (`numero`, `id_balance`, `cuenta_contable`, `debe`, `haber`, `deudor`, `acreedor`) VALUES
(1, 1, 'ACREEDORES', 0, 1000, 0, 1000),
(1, 2, 'ACREEDORES', 0, 1000, 0, 1000),
(2, 1, 'BANCOS', 13600, 0, 13600, 0),
(2, 2, 'BANCOS', 13600, 0, 13600, 0),
(3, 1, 'CAJA', 34800, 1820, 32980, 0),
(3, 2, 'CAJA', 34800, 1820, 32980, 0),
(4, 1, 'CAJA GENERAL', 0, 100, 0, 100),
(4, 2, 'CAJA GENERAL', 0, 100, 0, 100),
(5, 1, 'CAPITAL', 0, 172840, 0, 172840),
(5, 2, 'CAPITAL', 0, 172840, 0, 172840),
(6, 1, 'CLIENTES', 7500, 1728, 5772, 0),
(6, 2, 'CLIENTES', 7500, 1728, 5772, 0),
(7, 1, 'COMPRAS', 1250, 0, 1250, 0),
(7, 2, 'COMPRAS', 1250, 0, 1250, 0),
(8, 1, 'DESCUENTOS SOBRE VENTAS', 650, 0, 650, 0),
(8, 2, 'DESCUENTOS SOBRE VENTAS', 650, 0, 650, 0),
(9, 1, 'DOCUMENTOS POR PAGAR', 0, 3500, 0, 3500),
(9, 2, 'DOCUMENTOS POR PAGAR', 0, 3500, 0, 3500),
(10, 1, 'IVA POR COBRAR', 16410, 0, 16410, 0),
(10, 2, 'IVA POR COBRAR', 16410, 0, 16410, 0),
(11, 1, 'IVA POR PAGAR', 78, 1907.14, 0, 1829.14),
(11, 2, 'IVA POR PAGAR', 78, 1907.14, 0, 1829.14),
(12, 1, 'MERCADERIAS', 35000, 0, 35000, 0),
(12, 2, 'MERCADERIAS', 35000, 0, 35000, 0),
(13, 1, 'MOBILIARIO Y EQUIPO', 15500, 0, 15500, 0),
(13, 2, 'MOBILIARIO Y EQUIPO', 15500, 0, 15500, 0),
(14, 1, 'PROVEEDORES', 0, 11000, 0, 11000),
(14, 2, 'PROVEEDORES', 0, 11000, 0, 11000),
(15, 1, 'VEHICULOS', 85000, 0, 85000, 0),
(15, 2, 'VEHICULOS', 85000, 0, 85000, 0),
(16, 1, 'VENTAS', 0, 15892.9, 0, 15892.9),
(16, 2, 'VENTAS', 0, 15892.9, 0, 15892.9);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `balance_general_detalles`
--

CREATE TABLE `balance_general_detalles` (
  `numero_movimiento` int(11) NOT NULL,
  `id_balance_general` int(11) NOT NULL,
  `cuenta_contable` varchar(250) NOT NULL,
  `saldo` float DEFAULT '0',
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `balance_general_detalles`
--

INSERT INTO `balance_general_detalles` (`numero_movimiento`, `id_balance_general`, `cuenta_contable`, `saldo`, `estado`) VALUES
(1, 1, 'CAJA', 32980, NULL),
(2, 1, 'BANCOS', 13600, NULL),
(3, 1, 'CLIENTES', 5772, NULL),
(4, 1, 'IVA POR COBRAR', 16410, NULL),
(5, 1, 'MERCADERIAS', 35000, NULL),
(6, 1, 'MOBILIARIO Y EQUIPO', 15500, NULL),
(7, 1, 'VEHICULOS', 85000, NULL),
(8, 1, 'IVA POR PAGAR', 1829.14, NULL),
(9, 1, 'ACREEDORES', 1000, NULL),
(10, 1, 'PROVEEDORES', 11000, NULL),
(11, 1, 'DOCUMENTOS POR PAGAR', 3500, NULL),
(12, 1, 'CAPITAL', 172840, NULL),
(13, 1, 'Ganacia del Ejercicio', 14093, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `balance_general_encabezados`
--

CREATE TABLE `balance_general_encabezados` (
  `id_balance_general` int(11) NOT NULL,
  `id_libro_balance` int(5) DEFAULT NULL,
  `fecha` date NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `balance_general_encabezados`
--

INSERT INTO `balance_general_encabezados` (`id_balance_general`, `id_libro_balance`, `fecha`, `estado`) VALUES
(1, 1, '2020-05-18', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bancos`
--

CREATE TABLE `bancos` (
  `id_banco` int(11) NOT NULL,
  `nombre_banco` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `bancos`
--

INSERT INTO `bancos` (`id_banco`, `nombre_banco`, `estado`) VALUES
(1, 'GyT Continental', 1),
(2, 'Banrural', 1),
(3, 'Bantrab', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `chequeras`
--

CREATE TABLE `chequeras` (
  `id_chequera` int(11) NOT NULL,
  `id_cuenta_bancaria` int(11) NOT NULL,
  `no_cheques` int(11) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `chequeras`
--

INSERT INTO `chequeras` (`id_chequera`, `id_cuenta_bancaria`, `no_cheques`, `estado`) VALUES
(1, 1, 30, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `conceptos`
--

CREATE TABLE `conceptos` (
  `id_concepto` int(11) NOT NULL,
  `nombre_concepto` varchar(45) DEFAULT NULL,
  `naturaleza_concepto` varchar(45) DEFAULT NULL,
  `estatus` varchar(12) DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `id_cuenta` varchar(20) NOT NULL,
  `id_tipo_cuenta` varchar(11) NOT NULL,
  `codigo` int(10) NOT NULL,
  `nombre` varchar(250) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`id_cuenta`, `id_tipo_cuenta`, `codigo`, `nombre`, `descripcion`, `estado`) VALUES
('0.0', '0', 0, 'VARIOS', 'VARISO', 1),
('1.1.1', '1.1', 1, 'CAJA', 'CAJA', 1),
('1.1.1.1', '1', 1, 'CAJA GENERAL', 'CAJA GENERAL', 1),
('1.1.2', '1.1', 2, 'BANCOS', 'BANCOS ', 1),
('1.1.2.1', '1.1', 6, 'BANCO G&T', '', 1),
('1.1.3', '1.1', 3, 'CLIENTES', 'Clienetes', 1),
('1.1.4', '1.1', 4, 'IVA POR COBRAR', 'IVA', 1),
('1.1.5', '1.1', 5, 'CUENTAS POR COBRAR', 'CUENTAS POR COBRAR', 1),
('1.1.7', '1.1', 7, 'MERCADERIAS', 'MERCA', 1),
('1.2.1', '1.2', 1, 'EQUIPO DE COMPUTO', 'EQUIPO', 1),
('1.2.2', '1.2', 2, 'MOBILIARIO Y EQUIPO', 'MOB', 1),
('1.2.3', '1.2', 3, 'VEHICULOS', 'RAAANN', 1),
('2.1.1', '2.1', 1, 'IVA POR PAGAR', 'IVA POR PAGAR BRO', 1),
('2.1.2', '2.1', 2, 'ACREEDORES', 'AAA TE CREAS', 1),
('2.1.3', '2.1', 3, 'PROVEEDORES', 'PRRRO', 1),
('2.2.1', '2.2', 1, 'DOCUMENTOS POR PAGAR', 'DOCS', 1),
('3.1.1', '3.1', 1, 'CAPITAL', 'CAPITAN CRUNCH', 1),
('4.1.1', '4.1', 1, 'VENTAS', 'S', 1),
('5.1.1', '5.1', 1, 'COMPRAS', 'COMPRAS', 1),
('6.1.1', '6.1', 1, 'DESCUENTOS SOBRE VENTAS', 'S', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas_bancarias`
--

CREATE TABLE `cuentas_bancarias` (
  `id_cuenta_bancaria` int(11) NOT NULL,
  `id_banco` int(11) NOT NULL,
  `no_cuenta_bancaria` int(11) NOT NULL,
  `id_modulo` int(11) NOT NULL,
  `fecha_apertura` date NOT NULL,
  `id_moneda` int(11) NOT NULL,
  `saldo` decimal(10,2) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuentas_bancarias`
--

INSERT INTO `cuentas_bancarias` (`id_cuenta_bancaria`, `id_banco`, `no_cuenta_bancaria`, `id_modulo`, `fecha_apertura`, `id_moneda`, `saldo`, `estado`) VALUES
(1, 1, 777, 1, '2020-04-11', 1, '13500.00', 1),
(2, 1, 2020, 2, '2020-04-20', 1, '51850.00', 1),
(3, 3, 351624, 1, '2020-04-20', 1, '816.00', 1),
(4, 2, 1234, 2, '2020-04-20', 1, '34000.00', 1),
(5, 1, 3456, 2, '2020-04-20', 1, '3900.50', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documentos`
--

CREATE TABLE `documentos` (
  `id_documento` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `estatus` varchar(12) DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `documentos`
--

INSERT INTO `documentos` (`id_documento`, `nombre`, `fecha`, `estatus`) VALUES
(1, 'FACTURA', '2020-04-01', 'activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresas`
--

CREATE TABLE `empresas` (
  `id_empresa` int(5) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empresas`
--

INSERT INTO `empresas` (`id_empresa`, `nombre`, `estado`) VALUES
(2, 'Bienestar', 1),
(3, 'Montreal', 1),
(4, 'PSA', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_de_resultados`
--

CREATE TABLE `estado_de_resultados` (
  `id_estado_de_resultado` int(11) NOT NULL,
  `id_libro_balance` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `estado_de_resultados`
--

INSERT INTO `estado_de_resultados` (`id_estado_de_resultado`, `id_libro_balance`, `fecha`, `estado`) VALUES
(1, 1, '2020-05-18', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_de_resultados_detalles`
--

CREATE TABLE `estado_de_resultados_detalles` (
  `numero_movimiento` int(11) NOT NULL,
  `id_estado_de_resultado` int(11) NOT NULL,
  `cuenta_contable` varchar(250) NOT NULL,
  `saldo` float DEFAULT '0',
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `estado_de_resultados_detalles`
--

INSERT INTO `estado_de_resultados_detalles` (`numero_movimiento`, `id_estado_de_resultado`, `cuenta_contable`, `saldo`, `estado`) VALUES
(2, 1, 'COMPRAS', 1250, NULL),
(3, 1, 'DESCUENTOS SOBRE VENTAS', 650, NULL),
(4, 1, 'Ganacia del Ejercicio', 13993, NULL),
(1, 1, 'VENTAS', 15892.9, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujo_efecctivo_encabezados`
--

CREATE TABLE `flujo_efecctivo_encabezados` (
  `id_flujo_efevtivo` int(11) NOT NULL,
  `total_efectivo` float DEFAULT '0',
  `estatus` varchar(12) DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro_diario_detalles`
--

CREATE TABLE `libro_diario_detalles` (
  `numero_movimiento` int(11) NOT NULL,
  `id_libro_diario` int(11) NOT NULL,
  `id_partida` int(11) NOT NULL,
  `cuenta_contable` varchar(250) CHARACTER SET utf8 NOT NULL,
  `debe` float NOT NULL DEFAULT '0',
  `haber` float NOT NULL DEFAULT '0',
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `libro_diario_detalles`
--

INSERT INTO `libro_diario_detalles` (`numero_movimiento`, `id_libro_diario`, `id_partida`, `cuenta_contable`, `debe`, `haber`, `estado`) VALUES
(0, 1, 1, 'CAJA', 22500, 0, 1),
(0, 1, 2, 'MOBILIARIO Y EQUIPO', 3500, 0, 1),
(0, 1, 3, 'CAJA', 780, 0, 1),
(0, 1, 4, 'COMPRAS', 1250, 0, 1),
(0, 1, 5, 'DESCUENTOS SOBRE VENTAS', 650, 0, 1),
(0, 1, 6, 'CAJA', 9520, 0, 1),
(0, 1, 7, 'BANCOS', 100, 0, 1),
(0, 1, 8, 'CAJA', 1000, 0, 1),
(0, 1, 9, 'CAJA', 1000, 0, 1),
(1, 1, 1, 'BANCOS', 13500, 0, 1),
(1, 1, 2, 'IVA POR COBRAR', 420, 0, 1),
(1, 1, 3, 'CLIENTES', 6500, 0, 1),
(1, 1, 4, 'IVA POR COBRAR', 150, 0, 1),
(1, 1, 5, 'IVA POR PAGAR', 78, 0, 1),
(1, 1, 6, 'VENTAS', 0, 8500, 1),
(1, 1, 7, 'CAJA GENERAL', 0, 100, 1),
(1, 1, 8, 'CLIENTES', 0, 1000, 1),
(1, 1, 9, 'VENTAS', 0, 892.86, 1),
(2, 1, 1, 'CLIENTES', 1000, 0, 1),
(2, 1, 2, 'CAJA', 0, 420, 1),
(2, 1, 3, 'VENTAS', 0, 6500, 1),
(2, 1, 4, 'CAJA', 0, 1400, 1),
(2, 1, 5, 'CLIENTES', 0, 728, 1),
(2, 1, 6, 'IVA POR PAGAR', 0, 1020, 1),
(2, 1, 9, 'IVA POR PAGAR', 0, 107.14, 1),
(3, 1, 1, 'IVA POR COBRAR', 15840, 0, 1),
(3, 1, 2, 'DOCUMENTOS POR PAGAR', 0, 3500, 1),
(3, 1, 3, 'IVA POR PAGAR', 0, 780, 1),
(4, 1, 1, 'MERCADERIAS', 35000, 0, 1),
(5, 1, 1, 'MOBILIARIO Y EQUIPO', 12000, 0, 1),
(6, 1, 1, 'VEHICULOS', 85000, 0, 1),
(7, 1, 1, 'PROVEEDORES', 0, 11000, 1),
(8, 1, 1, 'ACREEDORES', 0, 1000, 1),
(9, 1, 1, 'CAPITAL', 0, 172840, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro_diario_encabezados`
--

CREATE TABLE `libro_diario_encabezados` (
  `id_libro_diario` int(11) NOT NULL,
  `empresa` varchar(250) NOT NULL,
  `fecha` date DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `libro_diario_encabezados`
--

INSERT INTO `libro_diario_encabezados` (`id_libro_diario`, `empresa`, `fecha`, `estado`) VALUES
(1, 'PSA', '2020-05-13', 1),
(2, 'PSA', '2020-05-17', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro_mayor_cuentas`
--

CREATE TABLE `libro_mayor_cuentas` (
  `cuenta_contable` varchar(250) CHARACTER SET utf8 NOT NULL,
  `id_libro_mayor` int(11) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `libro_mayor_cuentas`
--

INSERT INTO `libro_mayor_cuentas` (`cuenta_contable`, `id_libro_mayor`, `estado`) VALUES
('ACREEDORES', 1, 1),
('BANCOS', 1, 1),
('CAJA', 1, 1),
('CAJA GENERAL', 1, 1),
('CAPITAL', 1, 1),
('CLIENTES', 1, 1),
('COMPRAS', 1, 1),
('DESCUENTOS SOBRE VENTAS', 1, 1),
('DOCUMENTOS POR PAGAR', 1, 1),
('IVA POR COBRAR', 1, 1),
('IVA POR PAGAR', 1, 1),
('MERCADERIAS', 1, 1),
('MOBILIARIO Y EQUIPO', 1, 1),
('PROVEEDORES', 1, 1),
('VEHICULOS', 1, 1),
('VENTAS', 1, 1),
('ACREEDORES', 2, 1),
('BANCOS', 2, 1),
('CAJA', 2, 1),
('CAJA GENERAL', 2, 1),
('CAPITAL', 2, 1),
('CLIENTES', 2, 1),
('COMPRAS', 2, 1),
('DESCUENTOS SOBRE VENTAS', 2, 1),
('DOCUMENTOS POR PAGAR', 2, 1),
('IVA POR COBRAR', 2, 1),
('IVA POR PAGAR', 2, 1),
('MERCADERIAS', 2, 1),
('MOBILIARIO Y EQUIPO', 2, 1),
('PROVEEDORES', 2, 1),
('VEHICULOS', 2, 1),
('VENTAS', 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro_mayor_detalles`
--

CREATE TABLE `libro_mayor_detalles` (
  `numero_detalle` int(11) NOT NULL,
  `id_libro_mayor` int(11) NOT NULL,
  `id_partida` int(20) NOT NULL,
  `cuenta_mayor` varchar(250) NOT NULL,
  `cuenta_contable` varchar(250) NOT NULL,
  `debe` float DEFAULT '0',
  `haber` float DEFAULT '0',
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `libro_mayor_detalles`
--

INSERT INTO `libro_mayor_detalles` (`numero_detalle`, `id_libro_mayor`, `id_partida`, `cuenta_mayor`, `cuenta_contable`, `debe`, `haber`, `estado`) VALUES
(1, 1, 1, 'ACREEDORES', 'CLIENTES', 1000, 0, 1),
(1, 2, 1, 'ACREEDORES', 'CLIENTES', 1000, 0, 1),
(2, 1, 7, 'BANCOS', 'CAJA GENERAL', 0, 100, 1),
(2, 2, 7, 'BANCOS', 'CAJA GENERAL', 0, 100, 1),
(3, 1, 1, 'BANCOS', 'VARIOS', 0, 13500, 1),
(3, 2, 1, 'BANCOS', 'VARIOS', 0, 13500, 1),
(4, 1, 1, 'CAJA', 'VARIOS', 0, 22500, 1),
(4, 2, 1, 'CAJA', 'VARIOS', 0, 22500, 1),
(5, 1, 3, 'CAJA', 'IVA POR PAGAR', 0, 780, 1),
(5, 2, 3, 'CAJA', 'IVA POR PAGAR', 0, 780, 1),
(6, 1, 6, 'CAJA', 'VARIOS', 0, 9520, 1),
(6, 2, 6, 'CAJA', 'VARIOS', 0, 9520, 1),
(7, 1, 8, 'CAJA', 'CLIENTES', 0, 1000, 1),
(7, 2, 8, 'CAJA', 'CLIENTES', 0, 1000, 1),
(8, 1, 9, 'CAJA', 'VARIOS', 0, 1000, 1),
(8, 2, 9, 'CAJA', 'VARIOS', 0, 1000, 1),
(9, 1, 2, 'CAJA', 'IVA POR COBRAR', 420, 0, 1),
(9, 2, 2, 'CAJA', 'IVA POR COBRAR', 420, 0, 1),
(10, 1, 4, 'CAJA', 'VARIOS', 1400, 0, 1),
(10, 2, 4, 'CAJA', 'VARIOS', 1400, 0, 1),
(11, 1, 7, 'CAJA GENERAL', 'BANCOS', 100, 0, 1),
(11, 2, 7, 'CAJA GENERAL', 'BANCOS', 100, 0, 1),
(12, 1, 1, 'CAPITAL', 'VARIOS', 172840, 0, 1),
(12, 2, 1, 'CAPITAL', 'VARIOS', 172840, 0, 1),
(13, 1, 3, 'CLIENTES', 'VENTAS', 0, 6500, 1),
(13, 2, 3, 'CLIENTES', 'VENTAS', 0, 6500, 1),
(14, 1, 1, 'CLIENTES', 'ACREEDORES', 0, 1000, 1),
(14, 2, 1, 'CLIENTES', 'ACREEDORES', 0, 1000, 1),
(15, 1, 8, 'CLIENTES', 'CAJA', 1000, 0, 1),
(15, 2, 8, 'CLIENTES', 'CAJA', 1000, 0, 1),
(16, 1, 5, 'CLIENTES', 'VARIOS', 728, 0, 1),
(16, 2, 5, 'CLIENTES', 'VARIOS', 728, 0, 1),
(17, 1, 4, 'COMPRAS', 'VARIOS', 0, 1250, 1),
(17, 2, 4, 'COMPRAS', 'VARIOS', 0, 1250, 1),
(18, 1, 5, 'DESCUENTOS SOBRE VENTAS', 'VARIOS', 0, 650, 1),
(18, 2, 5, 'DESCUENTOS SOBRE VENTAS', 'VARIOS', 0, 650, 1),
(19, 1, 2, 'DOCUMENTOS POR PAGAR', 'MOBILIARIO Y EQUIPO', 3500, 0, 1),
(19, 2, 2, 'DOCUMENTOS POR PAGAR', 'MOBILIARIO Y EQUIPO', 3500, 0, 1),
(20, 1, 2, 'IVA POR COBRAR', 'CAJA', 0, 420, 1),
(20, 2, 2, 'IVA POR COBRAR', 'CAJA', 0, 420, 1),
(21, 1, 4, 'IVA POR COBRAR', 'VARIOS', 0, 150, 1),
(21, 2, 4, 'IVA POR COBRAR', 'VARIOS', 0, 150, 1),
(22, 1, 1, 'IVA POR COBRAR', 'VARIOS', 0, 15840, 1),
(22, 2, 1, 'IVA POR COBRAR', 'VARIOS', 0, 15840, 1),
(23, 1, 5, 'IVA POR PAGAR', 'VARIOS', 0, 78, 1),
(23, 2, 5, 'IVA POR PAGAR', 'VARIOS', 0, 78, 1),
(24, 1, 6, 'IVA POR PAGAR', 'VARIOS', 1020, 0, 1),
(24, 2, 6, 'IVA POR PAGAR', 'VARIOS', 1020, 0, 1),
(25, 1, 9, 'IVA POR PAGAR', 'VARIOS', 107.14, 0, 1),
(25, 2, 9, 'IVA POR PAGAR', 'VARIOS', 107.14, 0, 1),
(26, 1, 3, 'IVA POR PAGAR', 'CAJA', 780, 0, 1),
(26, 2, 3, 'IVA POR PAGAR', 'CAJA', 780, 0, 1),
(27, 1, 1, 'MERCADERIAS', 'VARIOS', 0, 35000, 1),
(27, 2, 1, 'MERCADERIAS', 'VARIOS', 0, 35000, 1),
(28, 1, 2, 'MOBILIARIO Y EQUIPO', 'DOCUMENTOS POR PAGAR', 0, 3500, 1),
(28, 2, 2, 'MOBILIARIO Y EQUIPO', 'DOCUMENTOS POR PAGAR', 0, 3500, 1),
(29, 1, 1, 'MOBILIARIO Y EQUIPO', 'VARIOS', 0, 12000, 1),
(29, 2, 1, 'MOBILIARIO Y EQUIPO', 'VARIOS', 0, 12000, 1),
(30, 1, 1, 'PROVEEDORES', 'VARIOS', 11000, 0, 1),
(30, 2, 1, 'PROVEEDORES', 'VARIOS', 11000, 0, 1),
(31, 1, 1, 'VEHICULOS', 'VARIOS', 0, 85000, 1),
(31, 2, 1, 'VEHICULOS', 'VARIOS', 0, 85000, 1),
(32, 1, 6, 'VENTAS', 'VARIOS', 8500, 0, 1),
(32, 2, 6, 'VENTAS', 'VARIOS', 8500, 0, 1),
(33, 1, 9, 'VENTAS', 'VARIOS', 892.86, 0, 1),
(33, 2, 9, 'VENTAS', 'VARIOS', 892.86, 0, 1),
(34, 1, 3, 'VENTAS', 'CLIENTES', 6500, 0, 1),
(34, 2, 3, 'VENTAS', 'CLIENTES', 6500, 0, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro_mayor_encabezados`
--

CREATE TABLE `libro_mayor_encabezados` (
  `id_libro_mayor` int(11) NOT NULL,
  `id_libro_diario` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `libro_mayor_encabezados`
--

INSERT INTO `libro_mayor_encabezados` (`id_libro_mayor`, `id_libro_diario`, `fecha`, `estado`) VALUES
(1, 1, '2020-05-18', 1),
(2, 1, '2020-05-18', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `modulos`
--

CREATE TABLE `modulos` (
  `id_modulo` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `modulos`
--

INSERT INTO `modulos` (`id_modulo`, `nombre`, `descripcion`, `estado`) VALUES
(1, 'FRM', 'FRM - Gustavo - Randy', 1),
(2, 'CRM', 'CRM - Victor', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `monedas`
--

CREATE TABLE `monedas` (
  `id_moneda` int(11) NOT NULL,
  `moneda` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `monedas`
--

INSERT INTO `monedas` (`id_moneda`, `moneda`, `estado`) VALUES
(1, 'Quetzales', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mov_bancarios`
--

CREATE TABLE `mov_bancarios` (
  `id_mov` int(11) NOT NULL,
  `id_cuenta_bancaria` int(11) NOT NULL,
  `tipo_mov` varchar(50) NOT NULL,
  `no_referencia` varchar(50) NOT NULL,
  `beneficiario` varchar(50) NOT NULL,
  `descripcion` text NOT NULL,
  `cargo_abono` varchar(50) NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `saldo` decimal(10,2) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mov_bancarios`
--

INSERT INTO `mov_bancarios` (`id_mov`, `id_cuenta_bancaria`, `tipo_mov`, `no_referencia`, `beneficiario`, `descripcion`, `cargo_abono`, `monto`, `saldo`, `estado`) VALUES
(1, 3, 'Deposito', '000001', 'Apertura', 'Apertura de Cuenta', 'Abono', '816.00', '816.00', 1),
(5, 1, 'Deposito', 'A-2030', '2', 'Traslado de fondos', 'Cargo', '200.00', '800.00', 1),
(6, 2, 'Cheque', 'A-20-04-20', '', 'Prestamo a FRM', 'Cargo', '3500.00', '46500.00', 1),
(7, 2, 'Transferencia', 'A-20.1-04-20', '1 - 777 - FRM', 'Transferencia a FRM', 'Cargo', '1000.00', '49000.00', 1),
(8, 1, 'Deposito', 'A-3434', '1 - 777 - FRM', 'Traslado de Fondos', 'Abono', '12500.00', '13500.00', 1),
(9, 2, 'Deposito', '1234', '8909801923 - JJGB', 'Bonificación Incentivo', 'Cargo', '250.00', '48750.00', 1),
(10, 2, 'Deposito', 'b2334', '2398238 - anonimo', 'Pago por servicio', 'Cargo', '1200.00', '47550.00', 1),
(11, 2, 'Transferencia', '234623', 'Auto-Repuestos AEY', 'Pago por repuestos', 'Cargo', '6550.00', '41000.00', 1),
(12, 4, 'Deposito', '000001', 'Apertura', 'Apertura de Cuenta', 'Abono', '34000.00', '34000.00', 1),
(13, 5, 'Deposito', '000001', 'Apertura', 'Apertura de Cuenta', 'Abono', '900.50', '900.50', 1),
(14, 5, 'Deposito', '345', '5 - 3456 - CRM', 'Aumento de fondos', 'Abono', '2500.00', '3400.50', 1),
(15, 5, 'Deposito', '657', 'FRM - 657', 'Aumento de Fondos', 'Abono', '500.00', '3900.50', 1),
(16, 2, 'Deposito', '777', '2 - 2020 - CRM', 'Fondos', 'Abono', '7000.00', '48000.00', 1),
(17, 2, 'Cheque', 'D-777', 'CRM - Victor', 'Bono', 'Abono', '350.00', '48350.00', 1),
(18, 2, 'Transferencia', '8724', '', 'Pago de Cliente', 'Abono', '3500.00', '51850.00', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `partidas`
--

CREATE TABLE `partidas` (
  `id_partida` int(10) NOT NULL,
  `id_libro_diario` int(10) NOT NULL,
  `concepto` varchar(250) NOT NULL,
  `fecha` date NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `partidas`
--

INSERT INTO `partidas` (`id_partida`, `id_libro_diario`, `concepto`, `fecha`, `estado`) VALUES
(1, 1, 'Valores iniciales', '2020-05-13', 1),
(2, 1, 'Compra de fotocopiadora', '2020-05-13', 1),
(3, 1, 'Ventas al Credito', '2020-05-13', 1),
(4, 1, 'Compras según factura 12500', '2020-05-13', 1),
(5, 1, 'Devolución de ventas', '2020-05-13', 1),
(6, 1, 'Ventas al contado', '2020-05-13', 1),
(7, 1, 'asds', '2020-05-17', 0),
(8, 1, 'Ayuda', '2020-05-17', 0),
(9, 1, 'Partida', '2020-05-18', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `poliza_detalles`
--

CREATE TABLE `poliza_detalles` (
  `numero_movimiento` int(5) NOT NULL,
  `id_poliza` int(11) NOT NULL,
  `id_cuenta` varchar(250) NOT NULL,
  `debe` float DEFAULT '0',
  `haber` float DEFAULT '0',
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `poliza_detalles`
--

INSERT INTO `poliza_detalles` (`numero_movimiento`, `id_poliza`, `id_cuenta`, `debe`, `haber`, `estado`) VALUES
(23, 1, '2020-05-17', 1000, 0, 1),
(24, 1, '2020-05-17', 0, 1000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `poliza_encabezados`
--

CREATE TABLE `poliza_encabezados` (
  `id_poliza` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `tipo_poliza` varchar(45) DEFAULT NULL,
  `fecha_inicio` date DEFAULT NULL,
  `fecha_fin` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `poliza_encabezados`
--

INSERT INTO `poliza_encabezados` (`id_poliza`, `fecha`, `tipo_poliza`, `fecha_inicio`, `fecha_fin`, `estado`) VALUES
(1, '2020-05-17', 'VENTAS', '2020-05-17', '2020-05-17', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `presupuesto_detalles`
--

CREATE TABLE `presupuesto_detalles` (
  `id_presupuesto` int(11) NOT NULL,
  `id_cuenta` int(11) NOT NULL,
  `monto` float DEFAULT '0',
  `estatus` varchar(12) DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `presupuesto_encabezados`
--

CREATE TABLE `presupuesto_encabezados` (
  `id_presupuesto` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `estatus` varchar(12) DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_cuentas`
--

CREATE TABLE `tipo_cuentas` (
  `id_tipo_cuenta` varchar(20) NOT NULL,
  `nombre_tipo_cuenta` varchar(25) DEFAULT NULL,
  `descripcion_tipo_cuenta` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipo_cuentas`
--

INSERT INTO `tipo_cuentas` (`id_tipo_cuenta`, `nombre_tipo_cuenta`, `descripcion_tipo_cuenta`, `estado`) VALUES
('0', 'VARIOS', '0', 1),
('1', 'ACTIVO', 'Bienes de la Empresa', 1),
('1.1', 'ACTIVO CORRIENTE', 'Bienes de la Empresa con movimiento al corto ', 1),
('1.2', 'ACTIVO NO CORRIENTE', 'Bienes de la Empresa con movimiento al largo ', 1),
('2', 'PASIVO', 'Obligaciones de la empresa', 1),
('2.1', 'PASIVO CORRIENTE', 'Obligaciones de la empresa a corto plazo', 1),
('2.2', 'PASIVO NO CORRIENTE', 'Obligaciones de la empresa a largo plazo', 1),
('3.1', 'PATRIMONIO', 'Deudas y aportes a la empresa', 1),
('4.1', 'INGRESOS', 'Cuentas que aumentan el patrimonio', 1),
('5.1', 'COMPRAS', 'Adquisiciones de la empresa', 1),
('6.1', 'GASTOS', 'Disminuyen el patrimonio', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_polizas`
--

CREATE TABLE `tipo_polizas` (
  `id_poliza` int(11) NOT NULL,
  `nombre` varchar(250) NOT NULL,
  `descripcion` varchar(250) NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tipo_polizas`
--

INSERT INTO `tipo_polizas` (`id_poliza`, `nombre`, `descripcion`, `estado`) VALUES
(1, 'VENTAS', 'VENTAS', 1),
(2, 'COMPRAS', 'Compras', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `balances`
--
ALTER TABLE `balances`
  ADD PRIMARY KEY (`id_libro_mayor`,`id_balance`) USING BTREE,
  ADD KEY `id_balance` (`id_balance`);

--
-- Indices de la tabla `balances_detalles`
--
ALTER TABLE `balances_detalles`
  ADD PRIMARY KEY (`cuenta_contable`,`id_balance`) USING BTREE,
  ADD KEY `id_balance` (`id_balance`);

--
-- Indices de la tabla `balance_general_detalles`
--
ALTER TABLE `balance_general_detalles`
  ADD PRIMARY KEY (`id_balance_general`,`numero_movimiento`) USING BTREE,
  ADD KEY `fk_tbl_BalanceGeneral_Detalle_tbl_cuentas_contables1_idx` (`cuenta_contable`);

--
-- Indices de la tabla `balance_general_encabezados`
--
ALTER TABLE `balance_general_encabezados`
  ADD PRIMARY KEY (`id_balance_general`),
  ADD KEY `id_libro_balance` (`id_libro_balance`);

--
-- Indices de la tabla `bancos`
--
ALTER TABLE `bancos`
  ADD PRIMARY KEY (`id_banco`);

--
-- Indices de la tabla `chequeras`
--
ALTER TABLE `chequeras`
  ADD PRIMARY KEY (`id_chequera`),
  ADD KEY `chequeras_cuentasBancarias` (`id_cuenta_bancaria`);

--
-- Indices de la tabla `conceptos`
--
ALTER TABLE `conceptos`
  ADD PRIMARY KEY (`id_concepto`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`id_cuenta`) USING BTREE,
  ADD KEY `fk_tbl_cuentas_contables_tbl_tipoCuentaContable1_idx` (`id_tipo_cuenta`),
  ADD KEY `nombre` (`nombre`);

--
-- Indices de la tabla `cuentas_bancarias`
--
ALTER TABLE `cuentas_bancarias`
  ADD PRIMARY KEY (`id_cuenta_bancaria`),
  ADD KEY `cuentasBancarias_bancos` (`id_banco`),
  ADD KEY `cuentasBancarias_monedas` (`id_moneda`),
  ADD KEY `cuentasBancarias_modulos` (`id_modulo`);

--
-- Indices de la tabla `documentos`
--
ALTER TABLE `documentos`
  ADD PRIMARY KEY (`id_documento`);

--
-- Indices de la tabla `empresas`
--
ALTER TABLE `empresas`
  ADD PRIMARY KEY (`id_empresa`);

--
-- Indices de la tabla `estado_de_resultados`
--
ALTER TABLE `estado_de_resultados`
  ADD PRIMARY KEY (`id_estado_de_resultado`),
  ADD KEY `id_libro_balance` (`id_libro_balance`);

--
-- Indices de la tabla `estado_de_resultados_detalles`
--
ALTER TABLE `estado_de_resultados_detalles`
  ADD PRIMARY KEY (`cuenta_contable`,`id_estado_de_resultado`),
  ADD KEY `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_cuentas_contabl_idx` (`cuenta_contable`),
  ADD KEY `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_estado_perdidas_g1` (`id_estado_de_resultado`);

--
-- Indices de la tabla `flujo_efecctivo_encabezados`
--
ALTER TABLE `flujo_efecctivo_encabezados`
  ADD PRIMARY KEY (`id_flujo_efevtivo`);

--
-- Indices de la tabla `libro_diario_detalles`
--
ALTER TABLE `libro_diario_detalles`
  ADD PRIMARY KEY (`numero_movimiento`,`id_libro_diario`,`id_partida`) USING BTREE,
  ADD KEY `cuenta_contable` (`cuenta_contable`),
  ADD KEY `id_libro_diario` (`id_libro_diario`),
  ADD KEY `id_partida` (`id_partida`);

--
-- Indices de la tabla `libro_diario_encabezados`
--
ALTER TABLE `libro_diario_encabezados`
  ADD PRIMARY KEY (`id_libro_diario`);

--
-- Indices de la tabla `libro_mayor_cuentas`
--
ALTER TABLE `libro_mayor_cuentas`
  ADD PRIMARY KEY (`id_libro_mayor`,`cuenta_contable`) USING BTREE,
  ADD KEY `libro_mayor_cuentas_ibfk_3` (`cuenta_contable`);

--
-- Indices de la tabla `libro_mayor_detalles`
--
ALTER TABLE `libro_mayor_detalles`
  ADD PRIMARY KEY (`numero_detalle`,`id_libro_mayor`),
  ADD KEY `fk_tbl_libroMayor_Detalle_tbl_libroMayor1` (`id_libro_mayor`),
  ADD KEY `id_partida` (`id_partida`),
  ADD KEY `libro_mayor_detalles_ibfk_1` (`cuenta_mayor`),
  ADD KEY `cuenta_contable` (`cuenta_contable`);

--
-- Indices de la tabla `libro_mayor_encabezados`
--
ALTER TABLE `libro_mayor_encabezados`
  ADD PRIMARY KEY (`id_libro_mayor`,`id_libro_diario`),
  ADD KEY `fk_tbl_libroMayor_tbl_libroDiario_Encabezado1` (`id_libro_diario`);

--
-- Indices de la tabla `modulos`
--
ALTER TABLE `modulos`
  ADD PRIMARY KEY (`id_modulo`);

--
-- Indices de la tabla `monedas`
--
ALTER TABLE `monedas`
  ADD PRIMARY KEY (`id_moneda`);

--
-- Indices de la tabla `mov_bancarios`
--
ALTER TABLE `mov_bancarios`
  ADD PRIMARY KEY (`id_mov`),
  ADD KEY `movBancarios_ctasBancarias` (`id_cuenta_bancaria`);

--
-- Indices de la tabla `partidas`
--
ALTER TABLE `partidas`
  ADD PRIMARY KEY (`id_libro_diario`,`id_partida`),
  ADD KEY `id_partida` (`id_partida`),
  ADD KEY `id_partida_2` (`id_partida`);

--
-- Indices de la tabla `poliza_detalles`
--
ALTER TABLE `poliza_detalles`
  ADD PRIMARY KEY (`numero_movimiento`,`id_cuenta`) USING BTREE,
  ADD KEY `añlas,_idx` (`id_poliza`),
  ADD KEY `,ñl_idx` (`id_cuenta`);

--
-- Indices de la tabla `poliza_encabezados`
--
ALTER TABLE `poliza_encabezados`
  ADD PRIMARY KEY (`id_poliza`),
  ADD KEY `tipo_poliza` (`tipo_poliza`);

--
-- Indices de la tabla `presupuesto_detalles`
--
ALTER TABLE `presupuesto_detalles`
  ADD PRIMARY KEY (`id_presupuesto`,`id_cuenta`),
  ADD KEY `fk_tbl_presupuesto_detalle_tbl_cuentas_contables1_idx` (`id_cuenta`);

--
-- Indices de la tabla `presupuesto_encabezados`
--
ALTER TABLE `presupuesto_encabezados`
  ADD PRIMARY KEY (`id_presupuesto`);

--
-- Indices de la tabla `tipo_cuentas`
--
ALTER TABLE `tipo_cuentas`
  ADD PRIMARY KEY (`id_tipo_cuenta`);

--
-- Indices de la tabla `tipo_polizas`
--
ALTER TABLE `tipo_polizas`
  ADD PRIMARY KEY (`id_poliza`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `balance_general_encabezados`
--
ALTER TABLE `balance_general_encabezados`
  MODIFY `id_balance_general` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `bancos`
--
ALTER TABLE `bancos`
  MODIFY `id_banco` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `chequeras`
--
ALTER TABLE `chequeras`
  MODIFY `id_chequera` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `conceptos`
--
ALTER TABLE `conceptos`
  MODIFY `id_concepto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cuentas_bancarias`
--
ALTER TABLE `cuentas_bancarias`
  MODIFY `id_cuenta_bancaria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `documentos`
--
ALTER TABLE `documentos`
  MODIFY `id_documento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `empresas`
--
ALTER TABLE `empresas`
  MODIFY `id_empresa` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `estado_de_resultados`
--
ALTER TABLE `estado_de_resultados`
  MODIFY `id_estado_de_resultado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `flujo_efecctivo_encabezados`
--
ALTER TABLE `flujo_efecctivo_encabezados`
  MODIFY `id_flujo_efevtivo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `libro_diario_encabezados`
--
ALTER TABLE `libro_diario_encabezados`
  MODIFY `id_libro_diario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `libro_mayor_encabezados`
--
ALTER TABLE `libro_mayor_encabezados`
  MODIFY `id_libro_mayor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `modulos`
--
ALTER TABLE `modulos`
  MODIFY `id_modulo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `monedas`
--
ALTER TABLE `monedas`
  MODIFY `id_moneda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `mov_bancarios`
--
ALTER TABLE `mov_bancarios`
  MODIFY `id_mov` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `poliza_detalles`
--
ALTER TABLE `poliza_detalles`
  MODIFY `numero_movimiento` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `presupuesto_encabezados`
--
ALTER TABLE `presupuesto_encabezados`
  MODIFY `id_presupuesto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipo_polizas`
--
ALTER TABLE `tipo_polizas`
  MODIFY `id_poliza` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `balances`
--
ALTER TABLE `balances`
  ADD CONSTRAINT `balances_ibfk_1` FOREIGN KEY (`id_libro_mayor`) REFERENCES `libro_mayor_encabezados` (`id_libro_mayor`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `balances_detalles`
--
ALTER TABLE `balances_detalles`
  ADD CONSTRAINT `balances_detalles_ibfk_1` FOREIGN KEY (`id_balance`) REFERENCES `balances` (`id_balance`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `balance_general_detalles`
--
ALTER TABLE `balance_general_detalles`
  ADD CONSTRAINT `fk_tbl_BalanceGeneral_Detalle_tbl_BalanceGeneral_Encabezado1` FOREIGN KEY (`id_balance_general`) REFERENCES `balance_general_encabezados` (`id_balance_general`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `balance_general_encabezados`
--
ALTER TABLE `balance_general_encabezados`
  ADD CONSTRAINT `balance_general_encabezados_ibfk_1` FOREIGN KEY (`id_libro_balance`) REFERENCES `balances` (`id_balance`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `chequeras`
--
ALTER TABLE `chequeras`
  ADD CONSTRAINT `chequeras_cuentasBancarias` FOREIGN KEY (`id_cuenta_bancaria`) REFERENCES `cuentas_bancarias` (`id_cuenta_bancaria`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `cuentas_ibfk_1` FOREIGN KEY (`id_tipo_cuenta`) REFERENCES `tipo_cuentas` (`id_tipo_cuenta`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuentas_bancarias`
--
ALTER TABLE `cuentas_bancarias`
  ADD CONSTRAINT `cuentasBancarias_bancos` FOREIGN KEY (`id_banco`) REFERENCES `bancos` (`id_banco`) ON UPDATE CASCADE,
  ADD CONSTRAINT `cuentasBancarias_modulos` FOREIGN KEY (`id_modulo`) REFERENCES `modulos` (`id_modulo`) ON UPDATE CASCADE,
  ADD CONSTRAINT `cuentasBancarias_monedas` FOREIGN KEY (`id_moneda`) REFERENCES `monedas` (`id_moneda`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `estado_de_resultados`
--
ALTER TABLE `estado_de_resultados`
  ADD CONSTRAINT `estado_de_resultados_ibfk_1` FOREIGN KEY (`id_libro_balance`) REFERENCES `balances` (`id_balance`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `estado_de_resultados_detalles`
--
ALTER TABLE `estado_de_resultados_detalles`
  ADD CONSTRAINT `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_estado_perdidas_g1` FOREIGN KEY (`id_estado_de_resultado`) REFERENCES `estado_de_resultados` (`id_estado_de_resultado`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `libro_diario_detalles`
--
ALTER TABLE `libro_diario_detalles`
  ADD CONSTRAINT `libro_diario_detalles_ibfk_1` FOREIGN KEY (`id_libro_diario`) REFERENCES `libro_diario_encabezados` (`id_libro_diario`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `libro_diario_detalles_ibfk_2` FOREIGN KEY (`id_partida`) REFERENCES `partidas` (`id_partida`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `libro_diario_detalles_ibfk_3` FOREIGN KEY (`cuenta_contable`) REFERENCES `cuentas` (`nombre`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `libro_mayor_cuentas`
--
ALTER TABLE `libro_mayor_cuentas`
  ADD CONSTRAINT `libro_mayor_cuentas_ibfk_2` FOREIGN KEY (`id_libro_mayor`) REFERENCES `libro_mayor_encabezados` (`id_libro_mayor`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `libro_mayor_detalles`
--
ALTER TABLE `libro_mayor_detalles`
  ADD CONSTRAINT `fk_tbl_libroMayor_Detalle_tbl_libroMayor1` FOREIGN KEY (`id_libro_mayor`) REFERENCES `libro_mayor_encabezados` (`id_libro_mayor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `libro_mayor_detalles_ibfk_1` FOREIGN KEY (`cuenta_mayor`) REFERENCES `cuentas` (`nombre`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `libro_mayor_detalles_ibfk_2` FOREIGN KEY (`id_partida`) REFERENCES `partidas` (`id_partida`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `libro_mayor_detalles_ibfk_3` FOREIGN KEY (`cuenta_contable`) REFERENCES `cuentas` (`nombre`);

--
-- Filtros para la tabla `libro_mayor_encabezados`
--
ALTER TABLE `libro_mayor_encabezados`
  ADD CONSTRAINT `fk_tbl_libroMayor_tbl_libroDiario_Encabezado1` FOREIGN KEY (`id_libro_diario`) REFERENCES `libro_diario_encabezados` (`id_libro_diario`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mov_bancarios`
--
ALTER TABLE `mov_bancarios`
  ADD CONSTRAINT `movBancarios_ctasBancarias` FOREIGN KEY (`id_cuenta_bancaria`) REFERENCES `cuentas_bancarias` (`id_cuenta_bancaria`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `partidas`
--
ALTER TABLE `partidas`
  ADD CONSTRAINT `partidas_ibfk_1` FOREIGN KEY (`id_libro_diario`) REFERENCES `libro_diario_encabezados` (`id_libro_diario`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `poliza_detalles`
--
ALTER TABLE `poliza_detalles`
  ADD CONSTRAINT `poliza_detalles_ibfk_1` FOREIGN KEY (`id_poliza`) REFERENCES `poliza_encabezados` (`id_poliza`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `presupuesto_detalles`
--
ALTER TABLE `presupuesto_detalles`
  ADD CONSTRAINT `fk_tbl_presupuesto_detalle_tbl_presupuesto_Encabezado1` FOREIGN KEY (`id_presupuesto`) REFERENCES `presupuesto_encabezados` (`id_presupuesto`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;


