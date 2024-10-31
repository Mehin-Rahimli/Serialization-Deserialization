namespace Lambdapractice
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Movie> movie = new List<Movie>();
            Movie movie1 = new Movie()
            {
                Name = "Shutting Island",
                Genre = "Fantastic",
                AgeLimit = 16,
                Time = 2.50,
                ReleaseTime = new DateTime(2016, 8, 27)


            };
           Movie movie2=new Movie
            {
                Name = " Inglorurious Basterds",
                Genre = "War",
                AgeLimit = 18,
                Time = 2.20,
                ReleaseTime = new DateTime(2019, 12, 18)


            } ;
            movie.Add(movie2);
            movie.Add(movie1);
            List<Booking> bookings = new List<Booking>();


            Booking booking1 = new Booking()
            {
                BookingNumber = 10,
                BookingDate = new DateTime(2016, 8, 30),
                CustomerAge = 20,
                Movie=movie1,


            };
            Booking booking2=new Booking()
            {
                BookingNumber = 27,
                BookingDate = new DateTime(2019, 12, 20),
                CustomerAge = 19,
                Movie = movie2,

            };
            bookings.Add(booking2);
            bookings.Add(booking1);

            Movie movie3 = movie.Find(m => m.Genre == "War");
            movie.Remove(movie3);



            List<Movie> CheckAge = movie.Where(m => m.AgeLimit > 18).ToList();
            CheckAge.ForEach(c => Console.WriteLine($"\n{c.Name}"));

            List<Movie> CheckTime = movie.Where(m => m.Time > 2.30).ToList();
            CheckTime.ForEach(c => Console.WriteLine($"\n{c.Name}"));
            DateTime oneyearago = DateTime.Now.AddYears(-1);
           
            List<Movie> ReleaseLastYear = movie.Where(m => m.ReleaseTime >= oneyearago).ToList();
            ReleaseLastYear.ForEach(c => Console.WriteLine($"\n{c.Name}"));

            List<Booking> CheckCustomerAge = bookings.Where(b => b.CustomerAge < b.Movie.AgeLimit).ToList();
            CheckCustomerAge.ForEach(b => Console.WriteLine($"\nBooking Number: {b.BookingNumber} for Movie: {b.Movie.Name}"));

            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            List<Booking> recentBookings = bookings.Where(b => b.BookingDate >= oneMonthAgo).ToList();
            recentBookings.ForEach(b => Console.WriteLine($"\nRecent Booking Number: {b.BookingNumber} for Movie: {b.Movie.Name}"));

            List<Booking> multipleSeatsBookings = bookings.Where(b => b.BookingNumber >= 3).ToList();
            multipleSeatsBookings.ForEach(b => Console.WriteLine($"\nMulti-seat Booking Number: {b.BookingNumber} for Movie: {b.Movie.Name}"));

            string specificMovieName = "Shutter Island";
            List<Booking> specificMovieBookings = bookings.Where(b => b.Movie.Name == specificMovieName).ToList();
            specificMovieBookings.ForEach(b => Console.WriteLine($"\nBooking for {specificMovieName} - Booking Number: {b.BookingNumber}, Customer Age: {b.CustomerAge}"));



        }




    }
}
