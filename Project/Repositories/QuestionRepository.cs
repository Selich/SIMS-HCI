using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

namespace Project.Repositories {
    public class QuestionRepository {

        public Model.Question SetQuestion (Model.Question question) {
            throw new NotImplementedException ();
        }

        public Model.Question GetQuestion (Model.Question question) {
            throw new NotImplementedException ();
        }

        public Model.Question AddQuestion (Model.Question question) {
            throw new NotImplementedException ();
        }

        public Model.Question RemoveQuestion (Model.Question question) {
            throw new NotImplementedException ();
        }
        public IEnumerable<Question> ReadCSV (string fileName) {
            string[] lines = File.ReadAllLines (System.IO.Path.ChangeExtension (fileName, ".csv"));

            return lines.Select (line => {
                string[] data = line.Split (';');

                Question q = new Question ();
                q.id = Int32.Parse (data[0]);
                q.question = data[1];
                q.answer = data[2];
                return q;

            });

        }

    }
}