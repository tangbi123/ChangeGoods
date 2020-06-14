 create database Change
 on
 (
 name = 'Change',
 filename = 'E:\DATA\Change_data.mdf',
 size = 5,
 maxsize = 500,
 filegrowth = 10%
 )

 log on
 (
 name = 'Change_log',
 filename = 'E:\DATA\Change_log.ldf',
 size = 3,
 filegrowth = 1
 )

--建库部分，自行根据数据库设置建库,名称要统一
--默认用户名：admin 密码：123456


--表内有些定义需要补充，用【】标识出

CREATE TABLE 会员表(
    用户号 CHAR(6) PRIMARY KEY,--用数字填充
    手机号 CHAR(11) check(patindex('%[A-Za-z]%',手机号)=0),--只支持国内，默认86,只检查了不允许存在字母
    邮箱 VARCHAR(30),--example@example.example,没检查格式问题
    密码 varchar(20) NOT NULL check(len(密码)>=6),--最少6位
    性别 VARCHAR(6) NOT NULL check(性别 in ('male','female')),--male;female
    昵称 NVARCHAR(10) NOT NULL,--汉字、数字、字母、字符（无空格检查）
    用户等级 INT DEFAULT'1' NOT NULL check(用户等级 between 1 and 5),--1-5五个等级，新用户默认为1
    信誉等级 INT DEFAULT'5' NOT NULL check(信誉等级 between 0 and 5),--5-0六个等级，新用户默认为5
    注册时间 DATE DEFAULT GETDATE(),--注册时间为填表时当前系统时间
);

CREATE TABLE 管理员(
    管理员id VARCHAR(10) PRIMARY KEY,--创建指定
    管理员昵称 NVARCHAR(15),
    密码 VARCHAR(15) NOT NULL check(len(密码)>=8),--密码至少8位 
    权限等级 INT DEFAULT'3' check(权限等级 between 1 and 3) --3为最高等级
);

CREATE TABLE 帖子表(
    帖子号 VARCHAR(15) PRIMARY KEY,--用数字填充
    帖子类别 NVARCHAR(10),--【待补充】
    用户id VARCHAR(10) FOREIGN KEY REFERENCES 会员表(用户号),
    帖子信息 NVARCHAR(100)--【这类是啥？待补充】
);

CREATE TABLE 商品表(
    商品号 VARCHAR(10) PRIMARY KEY,--数字填充
    所属用户id VARCHAR(10) FOREIGN KEY REFERENCES 会员表(用户号),
    帖子号 VARCHAR(15) FOREIGN KEY REFERENCES 帖子表(帖子号),
    商品名称 NVARCHAR(15),
    价格 FLOAT,
    类别 NVARCHAR(10),

);

create TABLE 退货表 (
    买家id varchar(10) FOREIGN KEY REFERENCES 会员表(用户号),--表内为用户号，用数字填充
    卖家id VARCHAR(10) FOREIGN KEY REFERENCES 会员表(用户号),--用户号
    商品id varchar(10) FOREIGN KEY REFERENCES 商品表(商品号),--商品号，用数字填充
    退款方式 VARCHAR(10) DEFAULT'wechat',--wechat;alipay;qq 三种方式
    退货方式  NVARCHAR(10) DEFAULT'面交'--面交；邮递两种方式
    PRIMARY KEY(买家id,卖家id,商品id)
);

CREATE TABLE 订单表(
    买家id VARCHAR(10) FOREIGN KEY REFERENCES 会员表(用户号),
    卖家id VARCHAR(10) FOREIGN KEY REFERENCES 会员表(用户号),
    商品id VARCHAR(10) FOREIGN KEY REFERENCES 商品表(商品号),
    支付方式 VARCHAR(10) DEFAULT'wechat',
    邮寄方式  NVARCHAR(10) DEFAULT'面交',
    PRIMARY KEY(买家id,卖家id,商品id)
);

CREATE table 违规词表(
    违规词编号 VARCHAR(15) PRIMARY KEY,
    内容 NVARCHAR(100) NOT NULL,
    添加人编号 VARCHAR(10) FOREIGN KEY REFERENCES 管理员(管理员id)
);



-----------------------------------
--2020.6.13  加一些信息
alter table 商品表
add  图片 varchar(40)

select * from 商品表


---------------------------------
--2020.6.14凡威修改商品表

alter table 商品表
add 商品描述 varchar(50)

alter table 商品表
drop constraint FK__商品表__帖子号__5BE2A6F2

alter table 商品表
drop column 帖子号