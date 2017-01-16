-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Czas generowania: 16 Sty 2017, 14:01
-- Wersja serwera: 10.1.19-MariaDB
-- Wersja PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `kck`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klub`
--

CREATE TABLE `klub` (
  `id_klub` int(9) NOT NULL,
  `nazwa` varchar(70) NOT NULL,
  `majatek` int(9) NOT NULL,
  `path` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `klub`
--

INSERT INTO `klub` (`id_klub`, `nazwa`, `majatek`, `path`) VALUES
(0, 'Real Madryt', 285679, 'mc.png'),
(1, 'FC Bialystok', 285674, 'barca.png'),
(2, 'ManUnite', 250890, 'barca.png');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `Imie` varchar(50) NOT NULL,
  `Nazwisko` varchar(100) NOT NULL,
  `login` varchar(50) NOT NULL,
  `haslo` varchar(50) NOT NULL,
  `wiek` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`Imie`, `Nazwisko`, `login`, `haslo`, `wiek`) VALUES
('Sebastian', 'Druc', 'root', 'root', 21);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zawodnicy`
--

CREATE TABLE `zawodnicy` (
  `id_zawodnik` int(9) NOT NULL,
  `imie` varchar(50) NOT NULL,
  `nazwisko` varchar(70) NOT NULL,
  `wartosc` int(9) NOT NULL,
  `pozycja` varchar(50) NOT NULL,
  `id_klub` int(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `zawodnicy`
--

INSERT INTO `zawodnicy` (`id_zawodnik`, `imie`, `nazwisko`, `wartosc`, `pozycja`, `id_klub`) VALUES
(0, 'Sebastian', 'Druc', 12, 'Pozycja', 0),
(1, 'Zawodnik', 'Nazwisko', 120892, 'POzycja', 2);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `klub`
--
ALTER TABLE `klub`
  ADD PRIMARY KEY (`id_klub`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`login`);

--
-- Indexes for table `zawodnicy`
--
ALTER TABLE `zawodnicy`
  ADD PRIMARY KEY (`id_zawodnik`),
  ADD KEY `id_klub` (`id_klub`);

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `zawodnicy`
--
ALTER TABLE `zawodnicy`
  ADD CONSTRAINT `zawodnicy_ibfk_1` FOREIGN KEY (`id_klub`) REFERENCES `klub` (`id_klub`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
