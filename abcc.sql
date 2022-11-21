-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 20-11-2022 a las 15:54:16
-- Versión del servidor: 5.7.17-log
-- Versión de PHP: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `abcc`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `Alta_producto` (IN `sku` VARCHAR(6), IN `art` VARCHAR(15), IN `marc` VARCHAR(15), IN `modelo` VARCHAR(20), IN `id_departamento` INT(1), IN `id_clase` INT(2), IN `id_familia` INT(3), IN `stock` INT(9), IN `cantidad` INT(9), IN `fa` DATE, IN `fb` DATE, IN `des` INT(1))  INSERT INTO inventario(sku,articulo,marca,modelo,id_departamento,id_clase,id_familia,stock,cantidad,fecha_alta,fecha_baja,Descontinuado) VALUES
(sku,art,marc,modelo,id_departamento,id_clase,id_familia,stock,cantidad,fa,fb,des)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `baja` (IN `id` VARCHAR(6))  DELETE FROM inventario WHERE sku = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cambio` (IN `id` INT(6), IN `art` VARCHAR(15), IN `mrc` VARCHAR(15), IN `model` VARCHAR(20), IN `idp` INT(1), IN `idc` INT(2), IN `idf` INT(1), IN `stck` INT(9), IN `cnt` INT(9), IN `fecha` DATE, IN `fechb` DATE, IN `de` INT)  UPDATE inventario SET articulo = art,marca = mrc,modelo = model,id_departamento = idp,id_clase = idc,id_familia = idf,stock = stck,cantidad = cnt,fecha_alta = fecha ,fecha_baja = fechb ,Descontinuado = de WHERE sku = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `prueba` (IN `id` VARCHAR(6), IN `art` VARCHAR(15))  UPDATE inventario SET articulo = art WHERE sku = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `vertodo` ()  SELECT * FROM inventario
INNER JOIN departamentos
 on inventario.id_departamento = departamentos.id
INNER JOIN clase on departamentos.id_clase = clase.id
INNER JOIN familia on clase.id_familia = familia.id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ver_datos_sku` (IN `id` VARCHAR(6))  SELECT sku,articulo,marca,modelo,id_departamento,id_clase,id_familia,stock,cantidad,fecha_alta,fecha_baja,Descontinuado FROM inventario where sku = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Ver_inventario` ()  SELECT * FROM inventario$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ver_por_sku` (IN `id` VARCHAR(6))  SELECT sku from inventario where sku = id$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clase`
--

CREATE TABLE `clase` (
  `id` int(1) NOT NULL,
  `nom_clase` varchar(15) NOT NULL,
  `id_familia` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `clase`
--

INSERT INTO `clase` (`id`, `nom_clase`, `id_familia`) VALUES
(1, 'comestibles', 5),
(2, 'licuadoras', 5),
(3, 'sofas', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamentos`
--

CREATE TABLE `departamentos` (
  `id` int(1) NOT NULL,
  `nom_departamento` varchar(15) NOT NULL,
  `id_clase` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `departamentos`
--

INSERT INTO `departamentos` (`id`, `nom_departamento`, `id_clase`) VALUES
(1, 'domesticos', 1),
(2, 'Electronica', 1),
(3, 'mueble suelto', 1),
(4, 'salas', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `familia`
--

CREATE TABLE `familia` (
  `id` int(3) NOT NULL,
  `nom_familia` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `familia`
--

INSERT INTO `familia` (`id`, `nom_familia`) VALUES
(1, 'licuadoras'),
(2, 'batidoras'),
(4, 'sin nombre'),
(5, 'Exclusivos');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `sku` varchar(6) NOT NULL,
  `articulo` text NOT NULL,
  `marca` text NOT NULL,
  `modelo` text NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `id_clase` int(11) NOT NULL,
  `id_familia` int(11) NOT NULL,
  `stock` int(9) NOT NULL,
  `cantidad` int(9) NOT NULL,
  `fecha_alta` date NOT NULL,
  `fecha_baja` date NOT NULL,
  `Descontinuado` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`sku`, `articulo`, `marca`, `modelo`, `id_departamento`, `id_clase`, `id_familia`, `stock`, `cantidad`, `fecha_alta`, `fecha_baja`, `Descontinuado`) VALUES
('abcd', 'tv', 'samsung', 'hd', 1, 2, 5, 5, 1, '2022-11-20', '1900-01-01', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clase`
--
ALTER TABLE `clase`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_familia` (`id_familia`);

--
-- Indices de la tabla `departamentos`
--
ALTER TABLE `departamentos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_clase` (`id_clase`);

--
-- Indices de la tabla `familia`
--
ALTER TABLE `familia`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`sku`),
  ADD KEY `id_departamento` (`id_departamento`),
  ADD KEY `id_familia` (`id_familia`),
  ADD KEY `id_clase` (`id_clase`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `departamentos`
--
ALTER TABLE `departamentos`
  MODIFY `id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `familia`
--
ALTER TABLE `familia`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `clase`
--
ALTER TABLE `clase`
  ADD CONSTRAINT `clase_ibfk_1` FOREIGN KEY (`id_familia`) REFERENCES `familia` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `departamentos`
--
ALTER TABLE `departamentos`
  ADD CONSTRAINT `departamentos_ibfk_1` FOREIGN KEY (`id_clase`) REFERENCES `clase` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD CONSTRAINT `inventario_ibfk_2` FOREIGN KEY (`id_departamento`) REFERENCES `departamentos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
