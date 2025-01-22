CREATE TABLE `Users` (
  `id` integer PRIMARY KEY,
  `email` varchar(255),
  `password` varchar(255),
  `status` tinyint
);

CREATE TABLE `Companies` (
  `id_user` int PRIMARY KEY,
  `adress` varchar(255),
  `telephone` varchar(255),
  `contact` varchar(255),
  `mobile` varchar(255),
  `status` tinyint
);

CREATE TABLE `Students` (
  `id_user` int PRIMARY KEY,
  `nie` integer,
  `name` varchar(255),
  `surname` varchar(255),
  `gendre` varchar(255),
  `birthdate` date,
  `phone` varchar(255),
  `emer_phone` varchar(255),
  `nationality` varchar(255),
  `car` tinyint,
  `address` varchar(255),
  `year` integer,
  `register_date` date,
  `cv` tinyint
);

CREATE TABLE `Notifications` (
  `id` integer PRIMARY KEY,
  `title` varchar(255),
  `descriptcion` varchar(255),
  `status` tinyint,
  `id_user` integer
);

CREATE TABLE `Offers` (
  `id` integer PRIMARY KEY,
  `description` varchar(255),
  `requiriments` varchar(255),
  `date` date,
  `location` varchar(255),
  `id_company` integer
);

CREATE TABLE `Students_Offers` (
  `id_user` integer,
  `id_company` integer,
  `presentation` varchar(255),
  `status` tinyint
);

CREATE TABLE `Course` (
  `id` integer PRIMARY KEY,
  `name` varchar(255),
  `acronim` varchar(255)
);

CREATE TABLE `Students_Courses` (
  `id_course` integer,
  `id_student` integer
);

ALTER TABLE `Companies` ADD FOREIGN KEY (`id_user`) REFERENCES `Users` (`id`);

ALTER TABLE `Students` ADD FOREIGN KEY (`id_user`) REFERENCES `Users` (`id`);

ALTER TABLE `Notifications` ADD FOREIGN KEY (`id_user`) REFERENCES `Users` (`id`);

ALTER TABLE `Offers` ADD FOREIGN KEY (`id_company`) REFERENCES `Companies` (`id_user`);

ALTER TABLE `Students_Offers` ADD FOREIGN KEY (`id_user`) REFERENCES `Students` (`id_user`);

ALTER TABLE `Students_Offers` ADD FOREIGN KEY (`id_company`) REFERENCES `Companies` (`id_user`);

ALTER TABLE `Students_Courses` ADD FOREIGN KEY (`id_course`) REFERENCES `Course` (`id`);

ALTER TABLE `Students_Courses` ADD FOREIGN KEY (`id_student`) REFERENCES `Students` (`id_user`);
