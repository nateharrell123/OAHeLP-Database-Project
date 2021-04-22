--Name data insert
DROP TABLE IF EXISTS #name_temp
SELECT dta.idx, dta.id AS OAID, dta.firstNm AS Fst, dta.middleNms AS Mid, dta.lastNm AS Lst
INTO #name_temp
FROM (
    VALUES 
        (1,N'ommw60',N'Nor',N'Binti',N'Ghazali'),
        (2,N'zqf6ee',N'Muhammad',N'Izhar Bin',N'Hanifah'),
        (3,N'te4z3c',N'Nor',N'Aisyah Rutel Binti',N'Ibrahim'),
        (4,N'oe04zh',N'Mohamad',N'Syukri Bin',N'Munir'),
        (5,N'mp96my',N'Mohd',N'Zaid Bin Modh',N'Hadi'),
        (6,N'lzpe68',N'Alias',N'Isa Bin',N'Idrus'),
        (7,N'jkwyi9',N'Alias',N'Binti',N'Hanifah'),
        (8,N'mevg4x',N'Nasaruddin',N'Nazeri Bin Abdul',N'Munir'),
        (9,N'ryguy5',N'Muhammad',N'Binti',N'Idrus'),
        (10,N'i3e4ec',N'Mohamad',N'Azman Bin',N'Ibrahim'),
        (11,N'l82ur5',N'Nur',N'Noor Azmi Bin',N'Jabar'),
        (12,N'g77psk',N'Noor',N'Zaid Bin Modh',N'Nikmat'),
        (13,N'f9z8h0',N'Haji',N'Husna Binti Shamsul',N'Jabar'),
        (14,N'ss6wll',N'Nor',N'Aisyah Rutel Binti',N'Munir'),
        (15,N'jkmicx',N'Haji',N'Binti',N'Nikmat'),
        (16,N'srotvc',N'Nor',N'Izhar Bin',N'Hamzah'),
        (17,N'smgomi',N'Mohd',N'Aisyah Rutel Binti',N'Jabar'),
        (18,N'p2qsck',N'Nasaruddin',N'Noor Azmi Bin',N'Hanifah'),
        (19,N'jbofom',N'Norshida',N'Bin',N'Hadi'),
        (20,N'fxe036',N'Mohamad',N'Binti',N'Yusuf'),
        (21,N'j54xr8',N'Haji',N'Najmi Bin',N'Baba'),
        (22,N'ptbo8d',N'Mohd',N'Firdaus Bin',N'Hadi'),
        (23,N'a54y3j',N'Noor',N'Izhar Bin',N'Munir'),
        (24,N'toi3y6',N'Mohd',N'Nazeri Bin Abdul',N'Yusuf'),
        (25,N'xjy7x9',N'Adham',N'Binti',N'Hanifah'),
        (26,N'pvzyee',N'Nabilatul',N'Syukri Bin',N'Munir'),
        (27,N'w7npgf',N'Nur',N'Noor Azmi Bin',N'Shamsuddin'),
        (28,N'uxuoc4',N'Nasaruddin',N'Nazeri Bin Abdul',N'Baba'),
        (29,N'lweb81',N'Adham',N'Binti',N'Nikmat'),
        (30,N'f8deqo',N'Nabilatul',N'Husna Binti Shamsul',N'Ibrahim'),
        (31,N'v6cu6t',N'Siti',N'Syukri Bin',N'Ahmad'),
        (32,N'lujn4p',N'Haji',N'Izhar Bin',N'Jabar'),
        (33,N'ujfhw8',N'Nur',N'Firdaus Bin',N'Hamzah'),
        (34,N'hvvf0h',N'Nor',N'Isa Bin',N'Yusuf'),
        (35,N'vpn96g',N'Haji',N'Firdaus Bin',N'Hamzah'),
        (36,N'ph3fum',N'Adham',N'Azman Bin',N'Yusuf'),
        (37,N'qm7z2m',N'Siti',N'Zaid Bin Modh',N'Idrus'),
        (38,N'g3y9f0',N'Shamsul',N'Hassan Bin Abdul',N'Jabar'),
        (39,N'i94xnb',N'Mohd',N'Izhar Bin',N'Jabar'),
        (40,N'n5uhse',N'Norshida',N'Nazeri Bin Abdul',N'Baba'),
        (41,N'xsh8ux',N'Mohd',N'Aisyah Rutel Binti',N'Hanifah'),
        (42,N'od74xi',N'Siti',N'Izhar Bin',N'Yusuf'),
        (43,N'ycc6ep',N'Mohd',N'Zaid Bin Modh',N'Hanifah'),
        (44,N'w8satl',N'Haji',N'Husna Binti Shamsul',N'Ghazali'),
        (45,N'x99ff2',N'Adham',N'Isa Bin',N'Hamzah'),
        (46,N'rm550v',N'Nasaruddin',N'Zaid Bin Modh',N'Ghazali'),
        (47,N'w7aogg',N'Adham',N'Husna Binti Shamsul',N'Ahmad'),
        (48,N'fivlmd',N'Alias',N'Azman Bin',N'Idrus'),
        (49,N'dt7gb4',N'Norshida',N'Bin',N'Nikmat'),
        (50,N'cu1o5p',N'Muhammad',N'Nazeri Bin Abdul',N'Jabar'),
        (51,N'aoe4j8',N'Alias',N'Bin',N'Yusuf'),
        (52,N'lurpdk',N'Alias',N'Zaid Bin Modh',N'Munir'),
        (53,N'lx8ig7',N'Siti',N'Binti',N'Baba'),
        (54,N'x1b62i',N'Muhammad',N'Aisyah Rutel Binti',N'Munir'),
        (55,N'iy73mq',N'Shamsul',N'Nazeri Bin Abdul',N'Yusuf'),
        (56,N'aq25nd',N'Mohamad',N'Aisyah Rutel Binti',N'Hadi'),
        (57,N'd5frhw',N'Haji',N'Najmi Bin',N'Ibrahim'),
        (58,N'chzv0n',N'Shamsul',N'Syukri Bin',N'Hamzah'),
        (59,N'ytwge2',N'Alias',N'Zaid Bin Modh',N'Jabar'),
        (60,N'ka3kmr',N'Nasaruddin',N'Zaid Bin Modh',N'Hadi'),
        (61,N'nnv6su',N'Noor',N'Husna Binti Shamsul',N'Hanifah'),
        (62,N'fatdev',N'Mohamad',N'Azman Bin',N'Ghazali'),
        (63,N'z68x8p',N'Adham',N'Aisyah Rutel Binti',N'Ahmad'),
        (64,N'ddhz3b',N'Muhammad',N'Nazeri Bin Abdul',N'Hanifah'),
        (65,N'mre8mq',N'Mohamad',N'Firdaus Bin',N'Abdullah'),
        (66,N'ibgxb9',N'Shamsul',N'Izhar Bin',N'Yusuf'),
        (67,N'zdkdm3',N'Muhammad',N'Aisyah Rutel Binti',N'Nikmat'),
        (68,N'du9t4k',N'Mohd',N'Husna Binti Shamsul',N'Shamsuddin'),
        (69,N'hlndm3',N'Norshida',N'Isa Bin',N'Hanifah'),
        (70,N't8069e',N'Muhammad',N'Aisyah Rutel Binti',N'Nikmat'),
        (71,N'fkv3du',N'Nasaruddin',N'Aisyah Rutel Binti',N'Shamsuddin'),
        (72,N'ud0bl7',N'Adham',N'Nazeri Bin Abdul',N'Baba'),
        (73,N's02ln6',N'Mohd',N'Nazeri Bin Abdul',N'Hadi'),
        (74,N'kjtccb',N'Norshida',N'Binti',N'Nikmat'),
        (75,N'equv0o',N'Adham',N'Zaid Bin Modh',N'Jabar'),
        (76,N'y5l9h6',N'Haji',N'Syukri Bin',N'Baba'),
        (77,N'lte60w',N'Alias',N'Syukri Bin',N'Nikmat'),
        (78,N'm6liht',N'Noor',N'Hassan Bin Abdul',N'Yusuf'),
        (79,N'qu4wm7',N'Siti',N'Hassan Bin Abdul',N'Ibrahim'),
        (80,N'zf5trl',N'Nabilatul',N'Bin',N'Shamsuddin'),
        (81,N'xxo218',N'Noor',N'Hassan Bin Abdul',N'Ahmad'),
        (82,N'wheu2i',N'Shamsul',N'Syukri Bin',N'Munir'),
        (83,N'g5rcff',N'Siti',N'Izhar Bin',N'Hamzah'),
        (84,N'uhly7j',N'Mohd',N'Izhar Bin',N'Shamsuddin'),
        (85,N'iyy350',N'Adham',N'Zaid Bin Modh',N'Hanifah'),
        (86,N'qbeesv',N'Muhammad',N'Azman Bin',N'Ahmad'),
        (87,N'icx874',N'Mohd',N'Najmi Bin',N'Munir'),
        (88,N'hwf8pd',N'Nasaruddin',N'Aisyah Rutel Binti',N'Abdullah'),
        (89,N'dsgg8w',N'Haji',N'Zaid Bin Modh',N'Shamsuddin'),
        (90,N'lurhul',N'Nabilatul',N'Azman Bin',N'Ahmad'),
        (91,N't04st7',N'Noor',N'Hassan Bin Abdul',N'Nikmat'),
        (92,N'rg6vtd',N'Alias',N'Isa Bin',N'Munir'),
        (93,N'dhqux6',N'Haji',N'Zaid Bin Modh',N'Hadi'),
        (94,N'gy1c18',N'Norshida',N'Syukri Bin',N'Shamsuddin'),
        (95,N'epsp7u',N'Norshida',N'Hassan Bin Abdul',N'Munir'),
        (96,N'n5bmvy',N'Haji',N'Azman Bin',N'Hamzah'),
        (97,N'mhvc38',N'Nur',N'Najmi Bin',N'Idrus'),
        (98,N'fk3nml',N'Siti',N'Syukri Bin',N'Jabar'),
        (99,N'ot13vr',N'Adham',N'Zaid Bin Modh',N'Hadi'),
        (100,N'npzncl',N'Mohamad',N'Nazeri Bin Abdul',N'Munir'),
        (101,N'kqrgts',N'Adham',N'Bin',N'Hanifah'),
        (102,N'sc36rg',N'Norshida',N'Azman Bin',N'Ahmad'),
        (103,N'mpxvec',N'Adham',N'Isa Bin',N'Shamsuddin'),
        (104,N'ebwxfy',N'Mohamad',N'Zaid Bin Modh',N'Abdullah'),
        (105,N'wadnh5',N'Siti',N'Syukri Bin',N'Ahmad'),
        (106,N'pype4w',N'Adham',N'Syukri Bin',N'Ahmad'),
        (107,N'iwf3v1',N'Mohd',N'Zaid Bin Modh',N'Hanifah'),
        (108,N'u020fa',N'Nasaruddin',N'Aisyah Rutel Binti',N'Ghazali'),
        (109,N'nt5ztm',N'Nor',N'Hassan Bin Abdul',N'Ibrahim'),
        (110,N'tr30qb',N'Siti',N'Noor Azmi Bin',N'Abdullah'),
        (111,N'lh6jkq',N'Norshida',N'Aisyah Rutel Binti',N'Jabar'),
        (112,N'cn1qx8',N'Nor',N'Isa Bin',N'Idrus'),
        (113,N'g3r695',N'Nor',N'Isa Bin',N'Ibrahim'),
        (114,N'mhiqb8',N'Siti',N'Husna Binti Shamsul',N'Shamsuddin'),
        (115,N'ecky01',N'Siti',N'Binti',N'Yusuf'),
        (116,N'hrsmjs',N'Siti',N'Aisyah Rutel Binti',N'Jabar'),
        (117,N'i0wo5d',N'Nur',N'Izhar Bin',N'Idrus'),
        (118,N'r76ctb',N'Mohamad',N'Bin',N'Ibrahim'),
        (119,N'kefl4e',N'Siti',N'Izhar Bin',N'Ghazali'),
        (120,N'd6prx0',N'Nur',N'Isa Bin',N'Hamzah'),
        (121,N'a3rs37',N'Nor',N'Bin',N'Hamzah'),
        (122,N'lyg1kv',N'Nabilatul',N'Firdaus Bin',N'Hadi'),
        (123,N'dg41mr',N'Shamsul',N'Binti',N'Hadi'),
        (124,N'yp37pt',N'Adham',N'Firdaus Bin',N'Hanifah'),
        (125,N'g76d9y',N'Mohamad',N'Noor Azmi Bin',N'Hanifah'),
        (126,N'xmnzcu',N'Adham',N'Zaid Bin Modh',N'Yusuf'),
        (127,N'wby33s',N'Shamsul',N'Nazeri Bin Abdul',N'Baba'),
        (128,N'wgsv8l',N'Nor',N'Syukri Bin',N'Hadi'),
        (129,N'fwojzv',N'Haji',N'Husna Binti Shamsul',N'Munir'),
        (130,N'f8tev6',N'Haji',N'Husna Binti Shamsul',N'Abdullah'),
        (131,N'jqiflk',N'Mohd',N'Azman Bin',N'Hanifah'),
        (132,N'vw76il',N'Alias',N'Zaid Bin Modh',N'Munir'),
        (133,N'omnx7b',N'Norshida',N'Izhar Bin',N'Yusuf'),
        (134,N'gbxysn',N'Haji',N'Najmi Bin',N'Munir'),
        (135,N'ph7fpa',N'Nur',N'Firdaus Bin',N'Hanifah'),
        (136,N'gc33fh',N'Mohd',N'Firdaus Bin',N'Baba'),
        (137,N'iy7ga8',N'Nor',N'Bin',N'Nikmat'),
        (138,N'ih38w4',N'Alias',N'Husna Binti Shamsul',N'Jabar'),
        (139,N'kke1i8',N'Mohd',N'Azman Bin',N'Hanifah'),
        (140,N'hv7qws',N'Nasaruddin',N'Noor Azmi Bin',N'Munir'),
        (141,N'zyltn5',N'Alias',N'Aisyah Rutel Binti',N'Hadi'),
        (142,N'b6q7mc',N'Muhammad',N'Izhar Bin',N'Abdullah'),
        (143,N'fo9rbx',N'Haji',N'Aisyah Rutel Binti',N'Idrus'),
        (144,N'uw3q43',N'Siti',N'Bin',N'Hanifah'),
        (145,N'cqyk0r',N'Alias',N'Aisyah Rutel Binti',N'Ghazali'),
        (146,N'sbsfzj',N'Nur',N'Firdaus Bin',N'Nikmat'),
        (147,N'qf49b5',N'Shamsul',N'Noor Azmi Bin',N'Idrus'),
        (148,N'd1cpxb',N'Adham',N'Husna Binti Shamsul',N'Hanifah'),
        (149,N'ra2iuq',N'Mohd',N'Zaid Bin Modh',N'Shamsuddin'),
        (150,N'xuyimz',N'Mohd',N'Husna Binti Shamsul',N'Baba'),
        (151,N'bfqjnp',N'Norshida',N'Noor Azmi Bin',N'Ghazali'),
        (152,N'j6qix0',N'Nasaruddin',N'Noor Azmi Bin',N'Yusuf'),
        (153,N'ybow9z',N'Adham',N'Syukri Bin',N'Jabar'),
        (154,N'un6w7q',N'Nabilatul',N'Firdaus Bin',N'Hanifah'),
        (155,N'pw60qh',N'Mohd',N'Syukri Bin',N'Nikmat'),
        (156,N'jbd3zo',N'Mohd',N'Najmi Bin',N'Idrus'),
        (157,N'vz9fpg',N'Alias',N'Husna Binti Shamsul',N'Hadi'),
        (158,N'mxtnaz',N'Alias',N'Binti',N'Ibrahim'),
        (159,N'gy0nxq',N'Mohd',N'Firdaus Bin',N'Hanifah'),
        (160,N'dfdiwc',N'Mohd',N'Zaid Bin Modh',N'Baba'),
        (161,N'qdpq9l',N'Mohamad',N'Nazeri Bin Abdul',N'Abdullah'),
        (162,N'pe0d0v',N'Haji',N'Azman Bin',N'Ghazali'),
        (163,N'u9ncsx',N'Nur',N'Bin',N'Hadi'),
        (164,N'zsr6k3',N'Mohd',N'Azman Bin',N'Idrus'),
        (165,N'x9caio',N'Haji',N'Bin',N'Yusuf'),
        (166,N'u0vcmn',N'Norshida',N'Nazeri Bin Abdul',N'Yusuf'),
        (167,N'rw2mhx',N'Nabilatul',N'Noor Azmi Bin',N'Idrus'),
        (168,N'z6umkl',N'Alias',N'Husna Binti Shamsul',N'Baba'),
        (169,N'ddfrsp',N'Haji',N'Binti',N'Munir'),
        (170,N'g2shvx',N'Adham',N'Bin',N'Hadi'),
        (171,N'lntuts',N'Noor',N'Bin',N'Jabar'),
        (172,N'ivkv2n',N'Mohd',N'Hassan Bin Abdul',N'Yusuf'),
        (173,N'gl6943',N'Mohd',N'Zaid Bin Modh',N'Munir'),
        (174,N'b579q2',N'Mohd',N'Nazeri Bin Abdul',N'Shamsuddin'),
        (175,N'nt2eka',N'Haji',N'Najmi Bin',N'Ghazali'),
        (176,N'gjuujx',N'Shamsul',N'Najmi Bin',N'Shamsuddin'),
        (177,N'pxao29',N'Adham',N'Bin',N'Baba'),
        (178,N'jgs6kg',N'Nur',N'Nazeri Bin Abdul',N'Hanifah'),
        (179,N't61qpw',N'Alias',N'Hassan Bin Abdul',N'Ghazali'),
        (180,N'oweh72',N'Noor',N'Firdaus Bin',N'Nikmat'),
        (181,N'z1sx4l',N'Nabilatul',N'Aisyah Rutel Binti',N'Nikmat'),
        (182,N'qwmbl1',N'Nur',N'Azman Bin',N'Abdullah'),
        (183,N'e184ll',N'Nor',N'Syukri Bin',N'Hanifah'),
        (184,N'nojtpd',N'Noor',N'Syukri Bin',N'Hadi'),
        (185,N'glu0cm',N'Adham',N'Syukri Bin',N'Nikmat'),
        (186,N'ah6mdf',N'Muhammad',N'Husna Binti Shamsul',N'Munir'),
        (187,N't2ykfb',N'Norshida',N'Hassan Bin Abdul',N'Hamzah'),
        (188,N'lk8f7p',N'Mohamad',N'Syukri Bin',N'Hadi'),
        (189,N'bgnztf',N'Mohd',N'Najmi Bin',N'Nikmat'),
        (190,N'ep9v81',N'Nur',N'Binti',N'Nikmat'),
        (191,N'zcf7n5',N'Ey Durian','',''),
        (192,N'fqwgnx',N'Nak Tilo','',''),
        (193,N'sg8u1k',N'Ey Cimcom','',''),
        (194,N'po0y17',N'Mat','',''),
        (195,N'vb6qw0',N'Manggis','',''),
        (196,N'aqc7c2',N'Halit','',''),
        (197,N'v7h76d',N'Nak Tikus','',''),
        (198,N'zns5tw',N'Ey Gajah','',''),
        (199,N'g0cfjz',N'Nak Beg','',''),
        (200,N'r0sg6d',N'Asep','',''),
        (201,N'ra2iuq',N'Wen','',''),
        (202,N'r76ctb',N'Keladi','',''),
        (203,N'epsp7u',N'Pacit Mong','',''),
        (204,N'g76d9y',N'Daziran','',''),
        (205,N'dg41mr',N'Kayu','',''),
        (206,N'lte60w',N'Kowow','',''),
        (207,N'qm7z2m',N'Kepayang','',''),
        (208,N'ujfhw8',N'Ey Celangeh','',''),
        (209,N't61qpw',N'Asah','',''),
        (210,N'p2qsck',N'Alosah','',''),
        (211,N'nt5ztm',N'Kelmarin','',''),
        (212,N'x9caio',N'Dong','',''),
        (213,N'mevg4x',N'Ey Safan','',''),
        (214,N'hwf8pd',N'Nak Mayeng','',''),
        (215,N'pe0d0v',N'Nak Besar','',''),
        (216,N'equv0o',N'Nak Cecik','',''),
        (217,N'xsh8ux',N'Sulit','','')
) dta(idx,id,firstNm, middleNms,lastNm)
LEFT JOIN [Subject].[Subject] S ON dta.id = S.OAHeLPID

INSERT INTO [Subject].[Name] (FirstName, MiddleNames, LastName)
SELECT Fst,Mid,Lst
FROM #name_temp TEMP

INSERT INTO [Subject].[SubjectName](SubjectID, NameID)
SELECT S.SubjectID, TEMP.idx
FROM [Subject].[Name] SN 
    JOIN #name_temp TEMP ON TEMP.idx = SN.NameID
    JOIN [Subject].[Subject] S ON TEMP.OAID = S.OAHeLPID --make sure this is doing what you want
ORDER BY S.SubjectID

DROP TABLE #name_temp