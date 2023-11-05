USE BMS;

CREATE TABLE BMS.dbo.[role]
(
    idRole
    int
    IDENTITY
(
    1,
    1
) NOT NULL,
    name varchar
(
    100
) COLLATE French_CI_AS NOT NULL,
    CONSTRAINT rolePK PRIMARY KEY
(
    idRole
)
    );

CREATE TABLE BMS.dbo.[user]
(
    idUser
    int
    IDENTITY
(
    1,
    1
) NOT NULL,
    firstName varchar
(
    100
) COLLATE French_CI_AS NULL,
    lastName varchar
(
    100
) COLLATE French_CI_AS NULL,
    email varchar
(
    250
) COLLATE French_CI_AS NULL,
    password varchar
(
    1000
) COLLATE French_CI_AS NULL,
    idRole int NOT NULL,
    isExternal int NOT NULL,
    CONSTRAINT userPK PRIMARY KEY
(
    idUser
),
    CONSTRAINT userFK FOREIGN KEY
(
    idRole
) REFERENCES BMS.dbo.[role]
(
    idRole
)
    );

CREATE TABLE BMS.dbo.typeSpace
(
    idTypeSpace int IDENTITY(1,1) NOT NULL,
    name        varchar(150) COLLATE French_CI_AS NULL,
    CONSTRAINT typeSpacePK PRIMARY KEY (idTypeSpace)
);

CREATE TABLE BMS.dbo.[space]
(
    idSpace
    int
    IDENTITY
(
    1,
    1
) NOT NULL,
    name varchar
(
    100
) COLLATE French_CI_AS NULL,
    description varchar
(
    450
) COLLATE French_CI_AS NULL,
    maxCapacity int NULL,
    urlImage varchar(450) COLLATE French_CI_AS NULL,
    idTypeSpace int NULL,
    CONSTRAINT spacePK PRIMARY KEY
(
    idSpace
),
    CONSTRAINT typeSpaceFK FOREIGN KEY
(
    idTypeSpace
) REFERENCES BMS.dbo.typeSpace
(
    idTypeSpace
)
    );

CREATE INDEX IX_Space_IdTypeSpace ON BMS.dbo.[space](idTypeSpace);

CREATE TABLE BMS.dbo.[option]
(
    idOption
    int
    IDENTITY
(
    1,
    1
) NOT NULL,
    name varchar
(
    100
) COLLATE French_CI_AS NULL,
    CONSTRAINT optionPK PRIMARY KEY
(
    idOption
)
    );


CREATE TABLE BMS.dbo.booking
(
    idBooking int IDENTITY(1,1) NOT NULL,
    startDate datetime NULL,
    endDate   datetime NULL,
    idSpace   int NOT NULL,
    createdBy int NULL,
    created   datetime NULL,
    CONSTRAINT bookingPK PRIMARY KEY (idBooking),
    CONSTRAINT spaceBookingFK FOREIGN KEY (idSpace) REFERENCES BMS.dbo.[space](idSpace),
    CONSTRAINT bookingUserFK FOREIGN KEY (createdBy) REFERENCES BMS.dbo.[user](idUser)
);

CREATE INDEX IX_Booking_IdSpace ON BMS.dbo.[booking](idSpace);

CREATE TABLE BMS.dbo.bookingUser
(
    idBooking int NOT NULL,
    idUser    int NOT NULL,
    CONSTRAINT bookingFK FOREIGN KEY (idBooking) REFERENCES BMS.dbo.[booking](idBooking),
    CONSTRAINT bookingUserFK2 FOREIGN KEY (idUser) REFERENCES BMS.dbo.[user](idUser)
);



CREATE TABLE BMS.dbo.optionSpace
(
    idOption int NULL,
    idSpace  int NULL,
    CONSTRAINT optionSpaceFK FOREIGN KEY (idOption) REFERENCES BMS.dbo.[option](idOption),
    CONSTRAINT spaceOptionSpaceFK FOREIGN KEY (idSpace) REFERENCES BMS.dbo.[space](idSpace)
);


CREATE TABLE BMS.dbo.optionTypeSpace
(
    idOption int NULL,
    idTypeSpace int NULL,
    CONSTRAINT optionTypeSpaceFK FOREIGN KEY (idTypeSpace) REFERENCES BMS.dbo.[typeSpace](idTypeSpace),
    CONSTRAINT optionFK FOREIGN KEY (idOption) REFERENCES BMS.dbo.[option](idOption)
);
