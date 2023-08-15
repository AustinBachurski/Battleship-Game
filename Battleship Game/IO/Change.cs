namespace Battleship_Game.IO
{
    public static class Change
    {
        /*
         * When converting from coordinates to index:
         *     Numeric part of the coordinate gets decremented to account for
         *     zero index of the array, then multiplied by 10 since this is
         *     the "10's place of the decimal number.
         * 
         *     Then the letter part of the index is converted to an int
         *     with 'A' being zero, 'B' being one, 'C' being three, etc.
         *     
         *     Add the two together to get the index.
         *     
         * The inverse happens when converting from index to coordinates.
         */

        public static string ToCoordinates(int index)
        {
            char x = (char)(index % 10 + 'A');
            string y = ((index / 10 + 1)).ToString();

            return x + y;
        }

        public static int ToIndex(string coordinates)
        {
            int xIndex = (int)coordinates[0] - 'A';
            int yIndex = (int.Parse(coordinates.Substring(1)) - 1) * 10;

            return xIndex + yIndex;
        }
    }
}