"use strict";

import express from "express";
import cors from "cors";

import logRouter from "./routes/logsRouter.js";
import triggerRouter from "./routes/triggersRouter.js";

const app = express();
const port = 7070;

app.use(cors());

app.use(express.json());
app.use(express.urlencoded({ extended: false }));

app.use("/api/logs", logRouter);

app.use("/api/triggers", triggerRouter)

app.listen(port, () => console.log(`Running on http://localhost:${port}`));
