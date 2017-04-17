//A struct is like a class, but when created, the default value is not null
//A struct is like a simple class
[System.Serializable]
public struct IntVector2 {

    public int x;
    public int y;

    public IntVector2(int x, int y)
    {
        //'this.x' refers to the x variable in the class, 'x' refers to the provided parameter in the method
        this.x = x;
        this.y = y;
    }

    //This creates a custom operator. This can be done for any object
    public static IntVector2 operator + (IntVector2 v1, IntVector2 v2)
    {
        return new IntVector2(v1.x + v2.x, v1.y + v2.y);
    }

    public static IntVector2 operator - (IntVector2 v)
    {
        return new IntVector2(-v.x, -v.y);
    }
}
