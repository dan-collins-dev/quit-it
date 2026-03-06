/**
 * @swagger
 * components:
 *  schemas:
 *    Log:
 *      type: Object
 *      required:
 *          - date
 *          - numOfCigarettes
 */

"use strict";

import express from "express";

const logRouter = express.Router();

const smokerLogs = [
    {
        id: 1,
        date: new Date(2026, 2, 1).getTime(), // March 1, 2026
        numOfCigarettes: 15,
    },
    {
        id: 2,
        date: new Date(2026, 2, 2).getTime(), // March 2, 2026
        numOfCigarettes: 12,
    },
    {
        id: 3,
        date: new Date(2026, 2, 3).getTime(), // March 3, 2026
        numOfCigarettes: 18,
    },
    {
        id: 4,
        date: new Date(2026, 2, 4).getTime(), // March 4, 2026
        numOfCigarettes: 10,
    },
    {
        id: 5,
        date: new Date(2026, 2, 5).getTime(), // March 5, 2026
        numOfCigarettes: 23,
    },
];

logRouter.get("/", async (req, res) => {
    res.status(200).json(smokerLogs);
});

export default logRouter