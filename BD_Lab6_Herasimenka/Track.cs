using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Windows;
using System.Text;



namespace BD_Lab6_Herasimenka
{
    public class Track
    {
        private bool _isTrackTitleChanged;
        private bool _isTrackDurationChanged;
        private bool _isArtistNameChanged;
        private bool _isAlbumTitleChanged;

        public int TrackID { get; set; }
        public String TrackTitle
        {
            get => _trackTitle;
            set { _trackTitle = value; _isTrackTitleChanged = true; }
        }
        private String _trackTitle;

        public TimeSpan TrackDuration
        {
            get => _trackDuration;
            set { _trackDuration = value; _isTrackDurationChanged = true; }
        }
        private TimeSpan _trackDuration;

        public String ArtistName
        {
            get => _artistName;
            set { _artistName = value; _isArtistNameChanged = true; }
        }
        private String _artistName;

        public String AlbumTitle
        {
            get => _albumTitle;
            set { _albumTitle = value; _isAlbumTitleChanged = true; }
        }
        private String _albumTitle;
        static SqlConnection connection;
        public Track()
        {

            var connString = ConfigurationManager
            .ConnectionStrings["DemoConnection"]
            .ConnectionString;

            connection = new SqlConnection(connString);
        }
        static Track()
        {
            var connString = ConfigurationManager
            .ConnectionStrings["DemoConnection"]
            .ConnectionString;
            connection = new SqlConnection(connString);
        }
        public override string ToString()
        {
            return String.Format("TrackID={0} - Title: {1} - Duration: {2} -Artist Name: {3} - Album Title: {4}",
         TrackID, TrackTitle, TrackDuration, ArtistName, AlbumTitle);
        }
        public static IEnumerable<Track> GetAllTracks()
        {
            var commandString = "SELECT TrackID, TrackTitle, TrackDuration,ArtistName,AlbumTitle FROM Tracks";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var trackId = reader.GetInt32(0);
                    var trackTitle = reader.GetString(1);
                    var trackDuration = reader.GetTimeSpan(2);
                    var artistName = reader.IsDBNull(3) ? null : reader.GetString(3);
                    var albumTitle = reader.IsDBNull(4) ? null : reader.GetString(4);
                    var track = new Track
                    {
                        TrackID = trackId,
                        TrackTitle = trackTitle,
                        TrackDuration = trackDuration,
                        ArtistName = artistName,
                        AlbumTitle = albumTitle
                    };
                    yield return track;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO Tracks (TrackTitle, TrackDuration,ArtistName,AlbumTitle)" + "VALUES (@trackTitle, @trackDuration, @artistName, @albumTitle)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[] {
             new SqlParameter("trackTitle", TrackTitle),
             new SqlParameter("trackDuration", TrackDuration),
             new SqlParameter("artistName", ArtistName),
             new SqlParameter("albumTitle", AlbumTitle),
             });
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вставке записи: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        public static Track GetTrack(int id)
        {
            foreach (var track in GetAllTracks())
            {
                if (track.TrackID == id)
                    return track;
            }
            return null;
        }
        public void Update()
        {
            var commandString = new StringBuilder("UPDATE Tracks SET ");

            if (_isTrackTitleChanged)
                commandString.Append("TrackTitle = @trackTitle, ");

            if (_isTrackDurationChanged)
                commandString.Append("TrackDuration = @trackDuration, ");

            if (_isArtistNameChanged)
                commandString.Append("ArtistName = @artistName, ");

            if (_isAlbumTitleChanged)
                commandString.Append("AlbumTitle = @albumTitle, ");

            commandString.Remove(commandString.Length - 2, 2);  
            commandString.Append(" WHERE TrackID = @trackId");

            using (var updateCommand = new SqlCommand(commandString.ToString(), connection))
            {
                if (_isTrackTitleChanged)
                    updateCommand.Parameters.AddWithValue("@trackTitle", TrackTitle);

                if (_isTrackDurationChanged)
                    updateCommand.Parameters.AddWithValue("@trackDuration", TrackDuration);

                if (_isArtistNameChanged)
                    updateCommand.Parameters.AddWithValue("@artistName", ArtistName ?? (object)DBNull.Value);

                if (_isAlbumTitleChanged)
                    updateCommand.Parameters.AddWithValue("@albumTitle", AlbumTitle ?? (object)DBNull.Value);

                updateCommand.Parameters.AddWithValue("@trackId", TrackID);
                try
                {
                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вставке записи: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
                _isTrackTitleChanged = false;
                _isTrackDurationChanged = false;
                _isArtistNameChanged = false;
                _isAlbumTitleChanged = false;
            }
        }

            public static void Delete(int trackID)
            {
                var commandString = "DELETE FROM Tracks WHERE(TrackID = @trackId)";
                SqlCommand deleteCommand = new SqlCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("trackId", trackID);
                try
                {
                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при вставке записи: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
