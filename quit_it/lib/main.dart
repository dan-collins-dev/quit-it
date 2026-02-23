import "package:flutter/material.dart";
import "package:quit_it/start_screen.dart";

void main() {
  runApp(
    MaterialApp(
      home: Scaffold(
        body: Container(
          decoration: const BoxDecoration(
            gradient: LinearGradient(
              begin: AlignmentGeometry.topCenter,
              end: AlignmentGeometry.bottomCenter,
              colors: [
                Color.fromARGB(255, 183, 45, 3),
                Color.fromARGB(255, 235, 84, 38),
              ],
            ),
          ),
          child: StartScreen(),
        ),
      ),
    ),
  );
}