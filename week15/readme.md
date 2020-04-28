#Week15

## Tuesday

Using layered abstraction on GameObjects (or perhaps, Indirection Layers)
+ [Using Layers of Indirection to conceptualize/implement complex transformations](https://answers.unity.com/questions/44641/how-to-scale-a-parent-without-scaling-children.html)

Abstraction in your object hierarchy can be very useful. A typical use is to create an anchor point for object rotation. You can also use it to make one object orbit another.

In this example, a sheep body grows and shrinks, but its body parts remain the same size and have the same "anchor" on the sheep's body.

Useful trick: If you want to move an object so that it is in the same position as another object, but do not want them in the same hierarchy, you can drag the object you want moved onto the other, reset its Transform, then drag it off the hierarchy.

UI making it look better