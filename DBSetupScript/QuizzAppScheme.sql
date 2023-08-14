CREATE TABLE [CATEGORIES] (
  [id] integer PRIMARY KEY identity,
  [name] nvarchar(255),
  [created_at] datetime
)
GO

CREATE TABLE [CATEGORIES_QUIZES] (
  [id] integer PRIMARY KEY identity,
  [category_id] integer,
  [quiz_id] integer
)
GO

CREATE TABLE [USERS] (
  [id] integer PRIMARY KEY identity,
  [name] nvarchar(255),
  [password] nvarchar(255),
  [email] nvarchar(255),
  [is_active] bit not null,
  [created_at] datetime
)
GO

CREATE TABLE [QUIZES] (
  [id] integer PRIMARY KEY identity,
  [name] nvarchar(255),
  [description] text,
  [possible_score] integer,
  [latest_score] integer,
  [latest_score_by] integer,
  [created_by] integer,
  [updated_by] integer,
  [created_at] datetime,
  [updated_at] datetime
)
GO

CREATE TABLE [QUESTIONS] (
  [id] integer PRIMARY KEY identity,
  [name] nvarchar(255),
  [type] nvarchar(255),
  [correct_answer] nvarchar(255),
  [score] integer,
  [quiz_id] integer,
  [created_at] datetime,
  [updated_at] datetime
)
GO

CREATE TABLE [FILL_IN_BLANK_QUESTIONS] (
  [id] integer PRIMARY KEY,
  [question_id] integer,
  [word_position] integer
)
GO

CREATE TABLE [MULTIPLE_CHOICE_QUESTIONS] (
  [id] integer PRIMARY KEY identity,
  [question_id] integer,
  [value_1] nvarchar(255),
  [value_2] nvarchar(255),
  [value_3] nvarchar(255),
  [value_4] nvarchar(255)
)
GO

ALTER TABLE [CATEGORIES_QUIZES] ADD FOREIGN KEY ([category_id]) REFERENCES [CATEGORIES] ([id])
GO

ALTER TABLE [CATEGORIES_QUIZES] ADD FOREIGN KEY ([quiz_id]) REFERENCES [QUIZES] ([id])
GO

ALTER TABLE [QUIZES] ADD FOREIGN KEY ([created_by]) REFERENCES [USERS] ([id])
GO

ALTER TABLE [QUIZES] ADD FOREIGN KEY ([updated_by]) REFERENCES [USERS] ([id])
GO

ALTER TABLE [QUIZES] ADD FOREIGN KEY ([latest_score_by]) REFERENCES [USERS] ([id])
GO

ALTER TABLE [QUESTIONS] ADD FOREIGN KEY ([quiz_id]) REFERENCES [QUIZES] ([id])
GO

ALTER TABLE [FILL_IN_BLANK_QUESTIONS] ADD FOREIGN KEY ([question_id]) REFERENCES [QUESTIONS] ([id])
GO

ALTER TABLE [MULTIPLE_CHOICE_QUESTIONS] ADD FOREIGN KEY ([question_id]) REFERENCES [QUESTIONS] ([id])
GO
