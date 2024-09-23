CREATE TABLE tasks (
    id SERIAL PRIMARY KEY,
    description TEXT NOT NULL,
    is_completed BOOLEAN NOT NULL DEFAULT FALSE
);
drop TABLE tasks;