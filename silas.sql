-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-01-2025 a las 21:10:20
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `silas`
--
CREATE DATABASE IF NOT EXISTS `silas` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `silas`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `company`
--

CREATE TABLE `company` (
  `tin` varchar(20) NOT NULL,
  `address` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  `legal_name` varchar(20) NOT NULL,
  `phone` int(20) NOT NULL,
  `point_contact` varchar(20) NOT NULL,
  `active` tinyint(4) NOT NULL,
  `pc_phone` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `degree`
--

CREATE TABLE `degree` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `acronyms` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `offers`
--

CREATE TABLE `offers` (
  `id` int(11) NOT NULL,
  `description` varchar(20) NOT NULL,
  `emited` date NOT NULL,
  `target` varchar(20) NOT NULL,
  `address` varchar(20) NOT NULL,
  `tittle` varchar(20) NOT NULL,
  `company_tin` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `request`
--

CREATE TABLE `request` (
  `id` int(11) NOT NULL,
  `cover_letter` varchar(500) NOT NULL,
  `request_status` tinyint(4) NOT NULL,
  `id_request` int(11) NOT NULL,
  `id_student` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `students`
--

CREATE TABLE `students` (
  `nie` varchar(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `surname_1` varchar(20) NOT NULL,
  `surname_2` varchar(20) NOT NULL,
  `gender` varchar(20) NOT NULL,
  `date_brith` date NOT NULL,
  `emergence_phone` varchar(20) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  `id_certificate/es` int(20) NOT NULL,
  `car` tinyint(4) NOT NULL,
  `finish_year` int(11) NOT NULL,
  `address` varchar(20) NOT NULL,
  `curriculum` tinyint(4) NOT NULL,
  `nacionality` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `register_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user`
--

CREATE TABLE `user` (
  `tin_id_card` varchar(20) NOT NULL,
  `passworld` varchar(20) NOT NULL,
  `name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `company`
--
ALTER TABLE `company`
  ADD PRIMARY KEY (`tin`),
  ADD KEY `cif` (`tin`);

--
-- Indices de la tabla `degree`
--
ALTER TABLE `degree`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `offers`
--
ALTER TABLE `offers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `company_tin` (`company_tin`);

--
-- Indices de la tabla `request`
--
ALTER TABLE `request`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dni_alumno` (`id_student`),
  ADD KEY `id_request` (`id_request`),
  ADD KEY `id_student` (`id_student`);

--
-- Indices de la tabla `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`nie`),
  ADD KEY `id_certificate/es` (`id_certificate/es`);

--
-- Indices de la tabla `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`tin_id_card`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `company`
--
ALTER TABLE `company`
  ADD CONSTRAINT `company_ibfk_1` FOREIGN KEY (`tin`) REFERENCES `user` (`tin_id_card`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `offers`
--
ALTER TABLE `offers`
  ADD CONSTRAINT `offers_ibfk_1` FOREIGN KEY (`company_tin`) REFERENCES `company` (`tin`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `request`
--
ALTER TABLE `request`
  ADD CONSTRAINT `request_ibfk_1` FOREIGN KEY (`id_request`) REFERENCES `offers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `request_ibfk_2` FOREIGN KEY (`id_student`) REFERENCES `students` (`nie`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`nie`) REFERENCES `user` (`tin_id_card`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `students_ibfk_2` FOREIGN KEY (`id_certificate/es`) REFERENCES `degree` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
