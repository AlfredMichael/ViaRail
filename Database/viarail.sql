-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jul 06, 2024 at 10:24 AM
-- Server version: 8.3.0
-- PHP Version: 8.1.2-1ubuntu2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `viarail`
--

-- --------------------------------------------------------

--
-- Table structure for table `adminregistration`
--

CREATE TABLE `adminregistration` (
  `id` int NOT NULL,
  `adminname` varchar(255) NOT NULL,
  `adminpin` varchar(255) NOT NULL,
  `adminemail` varchar(500) NOT NULL,
  `adminphonenumber` varchar(255) NOT NULL,
  `adminpassword` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `adminregistration`
--

INSERT INTO `adminregistration` (`id`, `adminname`, `adminpin`, `adminemail`, `adminphonenumber`, `adminpassword`) VALUES
(2, 'Alfreddy', 'w456dfy', 'success_fred@gmail.com', '+2347055277151', '641890219989519581101501581612559294203219190239'),
(6, 'Michael', '50012wfr', 'success_fred@yahoo.com', '0904455645', '155187759016117204418013219421716618523240189109251');

-- --------------------------------------------------------

--
-- Table structure for table `adminreply`
--

CREATE TABLE `adminreply` (
  `id` int NOT NULL,
  `pas_username` varchar(500) NOT NULL,
  `pas_heading` varchar(500) NOT NULL,
  `pas_message` varchar(500) NOT NULL,
  `pas_date` varchar(255) NOT NULL,
  `pas_time` text NOT NULL,
  `admin_name` varchar(500) NOT NULL,
  `admin_message` varchar(500) NOT NULL,
  `admin_date` varchar(255) NOT NULL,
  `admin_time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `adminreply`
--

INSERT INTO `adminreply` (`id`, `pas_username`, `pas_heading`, `pas_message`, `pas_date`, `pas_time`, `admin_name`, `admin_message`, `admin_date`, `admin_time`) VALUES
(2, 'ALFREDTHEDEVELOPER', 'fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', 'ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', '2/7/2022', '05:31:54 PM', 'ADMINISTRATOR', 'ffffffffffffffffffffffffffff', '2/7/2022', '09:18:31 PM');

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `id` int NOT NULL,
  `fullname` varchar(500) NOT NULL,
  `username` varchar(500) NOT NULL,
  `phonenumber` varchar(500) NOT NULL,
  `email` varchar(500) NOT NULL,
  `bookingcode` varchar(500) NOT NULL,
  `seatno` int NOT NULL,
  `trainname` varchar(500) NOT NULL,
  `source` varchar(500) NOT NULL,
  `destination` varchar(500) NOT NULL,
  `date` varchar(255) NOT NULL,
  `arrivaltime` text NOT NULL,
  `trainid` int NOT NULL,
  `departuretime` text NOT NULL,
  `totaltime` varchar(500) NOT NULL,
  `ticketfare` varchar(500) NOT NULL,
  `distance` varchar(500) NOT NULL,
  `time` text NOT NULL,
  `station` varchar(500) NOT NULL,
  `tripcode` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `booking`
--

INSERT INTO `booking` (`id`, `fullname`, `username`, `phonenumber`, `email`, `bookingcode`, `seatno`, `trainname`, `source`, `destination`, `date`, `arrivaltime`, `trainid`, `departuretime`, `totaltime`, `ticketfare`, `distance`, `time`, `station`, `tripcode`) VALUES
(5, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'NRCHFRFNKV', 12, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(6, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'QQBQQDYVJN', 9, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(7, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'PCSLOOVFCV', 10, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(8, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'LAMRYSTMJV', 13, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(9, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'HNVNWALLGK', 8, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(10, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'PUQTKCMGAU', 2, 'Falcon505', 'Mannitoba', 'Toronto', '0000-00-00', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(13, 'Alfred Michael', 'Alfredthedeveloper', '08037254700', 'success_fred@yahoo.com', 'ELUWHJUEYU', 3, 'Falcon505', 'Mannitoba', 'Toronto', '12/12/2022 12:00:00 AM', '11:04:26 AM', 3, '12:04:26 AM', '3 hours', '$600', '12,000Km', '5:19:00 PM', 'Mannitoba plot B', 'JVQUEIK'),
(38, 'Jennifer Laurence', 'JJ', '0803333333', 'JJ@gmail.com', 'YCEHBJEKJT', 5, 'Falcon404', 'Toronto', 'Montrea\'l', '2/17/2022 12:00:00 AM', '7:30:00 AM', 11, '8:00:00 AM', '5 hours', '$400', '12,000km', '1:00:00 PM', 'Toronto main station', 'LXTDOVB'),
(39, 'Success Michael', 'mikey', '22', 'mikey@gmail.com', 'LOOGOPJBVD', 0, 'Kert405', 'Toronto', 'Vancouver', '22/02/02 12:00:00 AM', '11:04:26 AM', 4, '12:04:26 AM', '6 hours', '$700', '13,000Km', '6:19:00 PM', 'Toronto plot B', 'SWWXTJT');

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE `message` (
  `id` int NOT NULL,
  `username` varchar(255) NOT NULL,
  `heading` varchar(500) NOT NULL,
  `message` varchar(700) NOT NULL,
  `time` text NOT NULL,
  `date` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `message`
--

INSERT INTO `message` (`id`, `username`, `heading`, `message`, `time`, `date`) VALUES
(1, 'ALFREDTHEDEVELOPER', 'fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', 'ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', '05:31:54 PM', '2/7/2022'),
(2, 'ALFREDTHEDEVELOPER', 'ff', 'ffff', '05:32:03 PM', '2/7/2022'),
(3, 'ALFREDTHEDEVELOPER', 'ff', 'ffff', '05:32:06 PM', '2/7/2022'),
(4, 'ALFREDTHEDEVELOPER', 'ff', 'ffff', '05:32:08 PM', '2/7/2022'),
(5, 'MOBPSYCHO100', 'Payment Process', 'Hello Via Rail, I would like to find out about the payment process at the station.', '01:55:36 PM', '2/17/2022'),
(6, 'FREDTHEDEVELOPER', 'Can i work at Via Rail', 'blahhhhhhhhhhhhhhhhhhhhhhhhhhhhh', '09:50:38 AM', '4/1/2022'),
(7, 'JJ', 'heyooo', 'testing', '12:37:42 AM', '3/29/2023');

-- --------------------------------------------------------

--
-- Table structure for table `passengersregistration`
--

CREATE TABLE `passengersregistration` (
  `id` int NOT NULL,
  `fullname` varchar(500) NOT NULL,
  `username` varchar(500) NOT NULL,
  `phonenumber` varchar(255) NOT NULL,
  `email` varchar(500) NOT NULL,
  `password` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `passengersregistration`
--

INSERT INTO `passengersregistration` (`id`, `fullname`, `username`, `phonenumber`, `email`, `password`) VALUES
(2, 'Alfred Michael', 'dgs', 'sssus', 'ssus', '19685884765245137335812552204179149761037196119218'),
(3, 'Alfred Michael', 'Alfredthedeveloper', '0803725470000', 'success_fred@yahoo.commm', '641890219989519581101501581612559294203219190239'),
(4, 'Alfred Tanjiro', 'Mobpsycho100', '+2347055277151', 'mobpsycho100@gmail.com', '199176891438491181131251601772272818614320167881548'),
(5, 'Alfred', 'tade', '+2347055277151', 'tade@gmail.com', '641890219989519581101501581612559294203219190239'),
(7, 'Alfred Michael', 'fredthedeveloper', '+2347055277151', 'success_fred@yahoo.com', '641890219989519581101501581612559294203219190239'),
(8, 'Alfred Michael', 'fredthedeve', '+2347055277151', 'success_fred@yahoo.com', '155187759016117204418013219421716618523240189109251'),
(9, 'Alfred Princess', 'chefpri', '+2348077255717', 'chefpri@gmail.com', '1199118597184291612027333122722295120050195552174'),
(10, 'Alfred S. Michael', 'Thedevil', '08044444', 'success_fred@yahoo.com', '641890219989519581101501581612559294203219190239'),
(11, 'Jennifer Laurence', 'JJ', '0803333333', 'JJ@gmail.com', '641890219989519581101501581612559294203219190239'),
(12, 'Success Michael', 'mikey', '22', 'mikey@gmail.com', '641890219989519581101501581612559294203219190239');

-- --------------------------------------------------------

--
-- Table structure for table `stations`
--

CREATE TABLE `stations` (
  `id` int NOT NULL,
  `stationname` varchar(500) NOT NULL,
  `city` varchar(500) NOT NULL,
  `street` varchar(500) NOT NULL,
  `opens` text NOT NULL,
  `closes` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `stations`
--

INSERT INTO `stations` (`id`, `stationname`, `city`, `street`, `opens`, `closes`) VALUES
(1, 'GARNEAU UC', 'Mannitoba', 'Plot OB (C Avenue)', '1:37:56 AM', '10:37:56 PM'),
(3, 'FELLAR (OC)', 'Garrikson', 'Plor (OK) cB Avenue', '7:39:36 PM', '8:39:36 PM'),
(5, 'Kamloops station', 'kamloops', 'kamloops. plot B', '12:00:00 AM', '9:00:00 PM'),
(6, 'Letterkenny Station', 'Letterkenny', 'County Donegal', '12:45:14 AM', '12:45:14 PM');

-- --------------------------------------------------------

--
-- Table structure for table `traintrips`
--

CREATE TABLE `traintrips` (
  `id` int NOT NULL,
  `trainname` varchar(500) NOT NULL,
  `source` varchar(500) NOT NULL,
  `destination` varchar(500) NOT NULL,
  `arrivaltime` text NOT NULL,
  `departuretime` text NOT NULL,
  `arrivalatdestinationtime` text NOT NULL,
  `totaltime` varchar(255) NOT NULL,
  `date` date NOT NULL,
  `noofseats` int NOT NULL,
  `ticketfare` varchar(255) NOT NULL,
  `tripcode` varchar(255) NOT NULL,
  `distance` varchar(500) NOT NULL,
  `station` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `traintrips`
--

INSERT INTO `traintrips` (`id`, `trainname`, `source`, `destination`, `arrivaltime`, `departuretime`, `arrivalatdestinationtime`, `totaltime`, `date`, `noofseats`, `ticketfare`, `tripcode`, `distance`, `station`) VALUES
(4, 'Kert405', 'Toronto', 'Vancouver', '11:04:26 AM', '12:04:26 AM', '6:19:00 PM', '6 hours', '2022-02-02', 3, '$700', 'SWWXTJT', '13,000Km', 'Toronto plot B'),
(11, 'Falcon404', 'Toronto', 'Montrea\'l', '7:30:00 AM', '8:00:00 AM', '1:00:00 PM', '5 hours', '2022-02-17', 10, '$400', 'LXTDOVB', '12,000km', 'Toronto main station'),
(12, 'Kert404', 'Toronto', 'British Columbia', '11:00:00 AM', '12:00:00 PM', '2:00:00 PM', '2 hours', '2022-02-15', 15, '$400', 'RANWXFX', '1,200Km', 'Toronto Main Station'),
(13, 'ee', 'ee', 'ee', '1:33:53 PM', '1:33:53 PM', '8:19:00 AM', 'e', '2021-12-15', 50, 'e', 'WCGJWBJ', 'e', 'e'),
(14, 'Falcon5', 'Kamloops', 'Mannitoba', '12:00:00 AM', '12:30:00 AM', '3:00:00 AM', '3 hours', '2022-04-19', 50, '$500', 'SSNRJHL', '120KM', 'Kamloops station'),
(15, 'LYIT Express', 'Letterkenny', 'Dublin', '12:40:54 AM', '1:40:54 AM', '5:19:00 AM', '2 hours', '2023-04-01', 50, '$300', 'DWDKTLB', '3000km', 'Letterkenny Station');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `adminregistration`
--
ALTER TABLE `adminregistration`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `adminreply`
--
ALTER TABLE `adminreply`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `passengersregistration`
--
ALTER TABLE `passengersregistration`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stations`
--
ALTER TABLE `stations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `traintrips`
--
ALTER TABLE `traintrips`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `adminregistration`
--
ALTER TABLE `adminregistration`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `adminreply`
--
ALTER TABLE `adminreply`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `booking`
--
ALTER TABLE `booking`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `message`
--
ALTER TABLE `message`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `passengersregistration`
--
ALTER TABLE `passengersregistration`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `stations`
--
ALTER TABLE `stations`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `traintrips`
--
ALTER TABLE `traintrips`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
