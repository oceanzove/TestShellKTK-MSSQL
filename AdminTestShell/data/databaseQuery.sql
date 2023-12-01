-- �������� ������� ����
CREATE TABLE role
(
    id        int IDENTITY PRIMARY KEY,
    role_name varchar(50) UNIQUE NOT NULL
);

-- �������� ������� �������������
CREATE TABLE "user"
(
    id       int IDENTITY PRIMARY KEY,
    username VARCHAR(50) UNIQUE           NOT NULL,
    fullName VARCHAR(90)                  NOT NULL,
    password VARCHAR(50)                  NOT NULL,
    role     INTEGER REFERENCES role (id) NOT NULL
);

-- �������� ������� �������
CREATE TABLE class
(
    id   int IDENTITY PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL
);

-- �������� ������� ���������
CREATE TABLE subject
(
    id       int IDENTITY PRIMARY KEY,
    name     VARCHAR(50) UNIQUE NOT NULL,
    class_id INTEGER REFERENCES class (id)
);

-- �������� ������� �������� � ���������
CREATE TABLE teacher_subject
(
    id         int IDENTITY PRIMARY KEY,
    teacher_id INTEGER REFERENCES "user" (id),
    subject_id INTEGER REFERENCES subject (id)
);

-- �������� ������� ������
CREATE TABLE test
(
    id            int IDENTITY PRIMARY KEY,
    name          VARCHAR(100) NOT NULL,
    description   TEXT,
    created_by    INTEGER REFERENCES "user" (id),
    created_at    DATETIME DEFAULT GETDATE(),
    subject_id    INTEGER REFERENCES subject (id),
    duration      int     NOT NULL,
    grading_scale TEXT
);

-- �������� ������� ��������
CREATE TABLE question
(
    id            int IDENTITY PRIMARY KEY,
    test_id       INTEGER REFERENCES test (id),
    question_text TEXT        NOT NULL,
    hint          TEXT,
    weight        INTEGER     NOT NULL,
    question_type VARCHAR(50) NOT NULL
);

-- �������� ������� ��������� ������
CREATE TABLE answer_option
(
    id          int IDENTITY PRIMARY KEY,
    question_id INTEGER REFERENCES question (id),
    answer_text TEXT NOT NULL
);

-- �������� ������� ���������� �������
CREATE TABLE correct_answer
(
    id                int IDENTITY PRIMARY KEY,
    question_id       INTEGER REFERENCES question (id),
    correct_option_id INTEGER REFERENCES answer_option (id)
);

-- �������� ������� ����������� ������
CREATE TABLE assigned_test
(
    id               int IDENTITY PRIMARY KEY,
    test_id          INTEGER REFERENCES test (id),
    assigned_by      INTEGER REFERENCES "user" (id),
    assigned_to      INTEGER REFERENCES "user" (id),
    attempts_allowed INTEGER NOT NULL,
    assigned_at      DATETIME DEFAULT GETDATE()
);

-- �������� ������� ����������� �����
CREATE TABLE test_result
(
    id               int IDENTITY PRIMARY KEY,
    assigned_test_id INTEGER REFERENCES assigned_test (id),
    start_time       DATETIME DEFAULT GETDATE(),
    end_time         DATETIME,
    score            FLOAT
);

insert into role (role_name)
values ('student');
insert into role (role_name)
values ('teacher');
insert into role (role_name)
values ('head teacher');
insert into role (role_name)
values ('admin');