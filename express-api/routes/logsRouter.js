import express from "express";
import path from "path"
import { fileURLToPath } from "url";
import fs from "fs/promises"
import { v4 } from "uuid"

const logRouter = express.Router();

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const logsFilePath = path.join(
    __dirname,
    "..",
    "data",
    "logs.json",
);

export function isNewDay(localTime, lastEntryDate) {
    const utcTime = new Date(localTime);
    const currentUtcDate = utcTime.toISOString().split('T')[0];
    const lastUtcDate = new Date(lastEntryDate).toISOString().split('T')[0];
    return currentUtcDate !== lastUtcDate;
}

async function getAllLogs() {
    try {
        const logData = await fs.readFile(logsFilePath);
        return JSON.parse(logData)
    } catch (error) {
        console.error(error);
    }
}

logRouter.get("/", async (req, res) => {
    const logs = await getAllLogs()
    res.status(200).json(logs);
});

logRouter.post("/", async (req, res) => {
    try {
        const logs = JSON.parse(await fs.readFile(logsFilePath));
        const newDay = isNewDay(new Date(), logs[logs.length -1 ].date)
        
        if (newDay) {
            const newLog = { id: v4(), date: Date.now(), numOfCigs: 1}
            logs.push(newLog);
            fs.writeFile(logsFilePath, JSON.stringify(logs));
            
            return res.status(201).json(newLog)
        } else {
            const today = logs[logs.length - 1]
            today.numOfCigs += 1;
            fs.writeFile(logsFilePath, JSON.stringify(logs));
            return res.status(200).json(today)
        }
        

    } catch (error) {
        res.status(400).json("Bad Request");
    }
});

export default logRouter