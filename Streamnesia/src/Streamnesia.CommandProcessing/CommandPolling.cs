using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Streamnesia.Payloads;

namespace Streamnesia.CommandProcessing
{
    public class CommandPolling
    {
        private readonly Random _rng = new Random();
        private ConcurrentDictionary<int, Payload>  _options;
        private Dictionary<string, int> _votes;

        public CommandPolling()
        {
            _options = new ConcurrentDictionary<int, Payload>();
            
            for(var i = 0; i < 4; i++)
            {
                var success = _options.TryAdd(i, null);
                if(!success)
                {
                    Console.WriteLine("Initialization of poll items failed.");
                }
            }

            _votes = new Dictionary<string, int>();
        }

        public void GeneratePoll(IEnumerable<Payload> payloads)
        {
            for(var i = 0; i < _options.Count; i++)
                _options[i] = null;

            Payload candidate = payloads.Random(_rng);
            for(var i = 0; i < _options.Count; i++)
            {
                while(_options.Any(o => o.Value != null && o.Value.Name == candidate.Name))
                {
                    candidate = payloads.Random(_rng);
                }

                _options[i] = candidate;
            }

            _votes.Clear();
        }

        public void Vote(string username, int vote)
        {
            if(vote < 0 || vote >= _options.Count)
                return;

            if(_votes.ContainsKey(username))
            {
                _votes[username] = vote;
            }
            else
            {
                _votes.Add(username, vote);
            }
        }

        public Payload GetPayloadAt(int vote)
        {
            if (vote < 0 || vote > 3)
                return null;

            return _options[vote];
        }

        public Payload GetPayloadWithMostVotes()
        {
            if(!_votes.Any())
            {
                return _options.Random(_rng).Value;
            }

            var mostVotedIndexes = GetMostVotedIndexes();

            if(mostVotedIndexes.Length == 1)
                return _options[mostVotedIndexes[0]];

            return _options[mostVotedIndexes.Random(_rng)];
        }

        public IEnumerable<PollOption> GetPollOptions()
        {
            return _options.Select((o, i) => new PollOption
            {
                Name = o.Value.Name,
                Index = i,
                Votes = _votes.Count(v => v.Value == i)
            });
        }

        private int[] GetMostVotedIndexes()
        {
            var indexes = new List<int>();
            var votes = new int[_options.Count()];
            
            foreach(var vote in _votes)
            {
                votes[vote.Value]++;
            }

            int mostVotes = 0;
            int index = 0;
            for(var i = 0; i < votes.Length; i++)
            {
                if(votes[i] == mostVotes)
                {
                    indexes.Add(i);
                }
                if(votes[i] > mostVotes)
                {
                    indexes.Clear();
                    mostVotes = votes[i];
                    index = i;
                    indexes.Add(i);
                }
            }

            return indexes.ToArray();
        }
    }

    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> input, Random rng)
        {
            return input.ElementAt(rng.Next(input.Count()));
        }
    }
}
