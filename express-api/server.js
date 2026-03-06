"use strict";

import express from "express";
import cors from "cors";
import swaggerJSDoc from "swagger-jsdoc";
import swaggerUI from "swagger-ui-express";
import logRouter from "./routes/logsRouter.js";

const app = express();
const port = 7070;



app.use(cors());

app.use("/api/logs", logRouter);

const options = {
    definition: {
        openapi: "3.1.0",
        info: {
            title: "Quit It Express API Docs",
            version: "0.1.0",
            description:
                "This is a simple CRUD API application made with Express and documented with Swagger",
        },
        servers: [
            {
                url: "http://localhost:7070",
            },
        ],
    },
    apis: ["./routes/*.js"],
};

const specs = swaggerJSDoc(options);
app.use("/api-docs", swaggerUI.serve, swaggerUI.setup(specs));

app.listen(port, () => console.log(`Running on http://localhost:${port}`));
