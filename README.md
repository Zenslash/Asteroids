# Asteroids
Clone of the 2D game Asteroids made on Unity 2021 1.6f1

## Description
The goal of the game is to get as many points as possible by shooting asteroids and UFO, while avoiding collisions with them.

The player controls a spaceship that can spin left and right, move only forward and shoot. The movement of the ship should be with acceleration and inertia. The screen does not restrict movement, but is a portal, i.e. if you hit the upper border, you will appear from the lower one.

The ship has two types of weapons:
- bullets hitting an asteroid break it into smaller fragments, having a higher speed; bullets hitting small asteroid or UFO leads to their destruction;
- the laser destroys all objects that it crosses. The player has a limited the number of laser shots. Shots replenish over time.

When a spaceship collides with an asteroid, a small asteroid or a UFO, a loss message with a score and an invitation to start the game is displayed.

After the start of the game, asteroids and UFO periodically appear.
Asteroids move in a random direction, while UFO chase the player. Asteroids and UFO do not collide with each other

## Controls

- Up Arrow - Fly forward
- Left, Right Arrow - Spin left, right
- Left Ctrl - Fire bullets
- Space - Fire laser
