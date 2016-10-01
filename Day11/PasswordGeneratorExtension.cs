using System.Linq;

namespace Day11
{
    public static class PasswordGeneratorExtensions
    {
        public static string GenerateNextPassword(this string currentPass)
        {
            // Convert password to char array
            char[] pass = currentPass.ToLowerInvariant().ToCharArray();
            
            // Store password length for later use
            var passLength = pass.Length;

            // Keep iterating until password is found
            do
            {
                // Keep track if we have succesfully found a new password
                // which should be validated
                bool hasChanged = false;

                // Loop through password and increment while taking care of
                // remainder if need
                for(int x = passLength - 1; x >= 0; --x)
                {
                    if(hasChanged)
                    {
                        break; // Stop loop
                    }

                    // Determine if this is a overflow otherwise just increment
                    if(pass[x] >= 'z')
                    {
                        pass[x] = 'a';
                    } else {
                        ++pass[x];
                        hasChanged = true;
                    }
                }

                // Nothing has changed so we'll perform a complete rollover
                if(!hasChanged)
                {
                    pass = new string('a', passLength).ToCharArray();
                }
            }
            // Validate if password satisfy requirements set by Security-Elf
            while(!(Requrement1(pass) && Requrement2(pass) && Requrement3(pass)));

            return new string(pass);
        }

        /***
        * Passwords must include one increasing straight of at least three letters,
        * like abc, bcd, cde, and so on, up to xyz. They cannot skip letters; abd
        * doesn't count.
        */
        private static bool Requrement1(char[] password)
        {
            for(int x=0; x<password.Length - 3; ++x)
            {
                if(password[x] == password[x+1] - 1 &&
                   password[x] == password[x+2] - 2)
                {
                    return true;
                }
            }

            return false;
        }

        /***
        * Passwords may not contain the letters i, o, or l, as these letters can
        * be mistaken for other characters and are therefore confusing.
        */
        private static bool Requrement2(char[] password)
        {
            return password.All(x => x != 'i' && x != 'o' && x != 'l');
        }

        /***
        * Passwords must contain at least two different, non-overlapping pairs
        * of letters, like aa, bb, or zz.
        */
        private static bool Requrement3(char[] password)
        {
            int counter = 0;

            for(int x=0; x<password.Length - 1; ++x)
            {
                if(password[x] == password[x +1])
                {
                    ++counter;
                    x = x +1;
                }
            }

            return counter >= 2;
        }
    }
}

