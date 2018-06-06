
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema carservice
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema carservice
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `carservice` DEFAULT CHARACTER SET utf8 ;
USE `carservice` ;

-- -----------------------------------------------------
-- Table `carservice`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `carservice`.`Client` (
  `clientId` INT NOT NULL AUTO_INCREMENT,
  `surname` VARCHAR(45) NULL,
  `name` VARCHAR(45) NULL,
  `patronymic` VARCHAR(45) NULL,
  `birthYear` INT NULL,
  `telephone` VARCHAR(20) NULL,
  PRIMARY KEY (`clientId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `carservice`.`Car`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `carservice`.`Car` (
  `carId` INT NOT NULL AUTO_INCREMENT,
  `brand` VARCHAR(128) NULL,
  `model`  VARCHAR(128) NULL,
  `year` INT NULL,
  `transmission` VARCHAR(45) NULL,
  `enginePower` INT NULL,
  `clientId` INT NULL,
  PRIMARY KEY (`carId`),
  INDEX `CarClientFK_idx` (`clientId` ASC),
  CONSTRAINT `CarClientFK`
    FOREIGN KEY (`clientId`)
    REFERENCES `carservice`.`Client` (`clientId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `carservice`.`Order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `carservice`.`Order` (
  `orderId` INT NOT NULL AUTO_INCREMENT,
  `timeStart` DATETIME NULL,
  `timeEnd` DATETIME NULL,
  `price` DECIMAL(2) NULL,
  `Description` VARCHAR(450) NULL,
  `carId` INT NULL,
  `clientId` INT NULL,
  PRIMARY KEY (`orderId`),
  INDEX `orderCarFK_idx` (`carId` ASC),
  INDEX `orderClientFK_idx` (`clientId` ASC),
  CONSTRAINT `orderCarFK`
    FOREIGN KEY (`carId`)
    REFERENCES `carservice`.`Car` (`carId`)
    ON DELETE SET NULL
    ON UPDATE SET NULL,
  CONSTRAINT `orderClientFK`
    FOREIGN KEY (`clientId`)
    REFERENCES `carservice`.`Client` (`clientId`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `carservice`.`Client`
-- -----------------------------------------------------
START TRANSACTION;
USE `carservice`;
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Ivanov', 'Sergei', 'Petrovich', 1989, '926321');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Petrov', 'Ivan', 'Ivanovich', 1990, '9879');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Sergeengko', 'Alexandor', 'Petrovich', 1987, '9269093');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Pavlov', 'Arthur', 'Ibragimovich', 1993, '924555');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Bubnov', 'Pavel', 'Valeryanovich', 1990, '92640');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Suchkov', 'Pavel', 'leonidovich', 1989, '9223034345');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Mamedov', 'Ruslan', 'Igorevich', 1994, '9223434556');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Papkin', 'Egor', 'Valentinovich', 2000, '9256767789');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Ivanov', 'Sergei', 'Petrovich', 1989, '926321');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Petrov', 'Ivan', 'Ivanovich', 1990, '9879');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Sergeengko', 'Alexandor', 'Petrovich', 1987, '9269093');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Pavlov', 'Arthur', 'Ibragimovich', 1993, '924555');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Bubnov', 'Pavel', 'Valeryanovich', 1990, '92640');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Suchkov', 'Pavel', 'leonidovich', 1989, '9223034345');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Mamedov', 'Ruslan', 'Igorevich', 1994, '9223434556');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Papkin', 'Egor', 'Valentinovich', 2000, '9256767789');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Bubnov', 'Sergei', 'Petrovich', 1989, '926321');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Bubnov', 'Ivan', 'Ivanovich', 1990, '9879');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Petrigeengko', 'Alexandor', 'Petrovich', 1987, '9269093');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Suchkov', 'Arthur', 'Valeryanovich', 1993, '924555');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Bubnov', 'Pavel', 'Valeryanovich', 1990, '92640');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Mamedov', 'Pavel', 'leonidovich', 1989, '9223034345');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Mamedov', '', 'Ibragimovich', 1994, '9223434556');
INSERT INTO `carservice`.`Client` (`clientId`, `surname`, `name`, `patronymic`, `birthYear`, `telephone`) VALUES (DEFAULT, 'Papkin', 'Ruslan', 'Valentinovich', 2000, '9256767789');


COMMIT;



-- -----------------------------------------------------
-- Data for table `carservice`.`Car` START AFTER INSERT INTO CLIENT
-- -----------------------------------------------------
START TRANSACTION;
USE `carservice`;
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'mitshubishi', 'lancer', 2008, 'CVT', 141, 1);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'mustang', 2004, 'AT', 340, 5);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'VAZ', '2114', 2004, 'MT', 87, 9);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'siera', 1989, 'MT', 89, 20);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'focus', 2008, 'AT', 100, 3);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'Focus', 2009, 'MT', 140, 5);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Mitshubishi', 'Galant', 2002, 'AT', 140, 7);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Nissan', 'qashqai', 2008, 'CVT', 141, 6);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'BMV', 'M3', 2015, 'AT', 240, 18);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'mitshubishi', 'lancer', 2008, 'CVT', 141, 8);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'mustang', 2004, 'AT', 340, 4);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'VAZ', '2114', 2004, 'MT', 87, 10);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'siera', 1989, 'MT', 89, 23);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'focus', 2008, 'AT', 100, 13);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Ford', 'Focus', 2009, 'MT', 140, 15);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Mitshubishi', 'Galant', 2002, 'AT', 140, 18);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'Nissan', 'qashqai', 2008, 'CVT', 141, 16);
INSERT INTO `carservice`.`Car` (`carId`, `brand`, `model`, `year`, `transmission`, `enginePower`, `clientId`) VALUES (DEFAULT, 'BMV', 'M3', 2015, 'AT', 240, 11);

COMMIT;


-- -----------------------------------------------------
-- Data for table `carservice`.`Order` START AFTER INSERT INTO CLIENT
-- -----------------------------------------------------
START TRANSACTION;
USE `carservice`;
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 1, 1);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 1000, 'масло замена', 2, 5);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 3, 9);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 4, 20);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 5, 3);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 6, 5);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 7, 7);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 8, 6);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 9, 18);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 10, 8);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 11, 4);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 12, 10);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 13, 23);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 14, 13);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 15, 15);
INSERT INTO `carservice`.`Order` (`orderId`, `timeStart`, `timeEnd`, `price`, `Description`, `carId`, `clientId`) VALUES (DEFAULT, NULL, NULL, 10000, 'Покраска', 16, 18);

COMMIT;



