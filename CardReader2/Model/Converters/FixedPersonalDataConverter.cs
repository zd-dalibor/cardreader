using CardReader.Model.Data.Eid;
using CardReader.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model.Converters
{
    internal class FixedPersonalDataConverter
    {
        public static FixedPersonalData From(IdReaderLib.EID_FIXED_PERSONAL_DATA data)
        {
            var fixedPersonalData = new FixedPersonalData
            {
                PersonalNumber = StringUtil.BytesToString(data.personalNumber, data.personalNumberSize),
                Surname = StringUtil.BytesToString(data.surname, data.surnameSize),
                GivenName = StringUtil.BytesToString(data.givenName, data.givenNameSize),
                ParentGivenName = StringUtil.BytesToString(data.parentGivenName, data.parentGivenNameSize),
                Sex = StringUtil.BytesToString(data.sex, data.sexSize),
                PlaceOfBirth = StringUtil.BytesToString(data.placeOfBirth, data.placeOfBirthSize),
                StateOfBirth = StringUtil.BytesToString(data.stateOfBirth, data.stateOfBirthSize),
                DateOfBirth = StringUtil.BytesToString(data.dateOfBirth, data.dateOfBirthSize),
                CommunityOfBirth = StringUtil.BytesToString(data.communityOfBirth, data.communityOfBirthSize),
                StatusOfForeigner = StringUtil.BytesToString(data.statusOfForeigner, data.statusOfForeignerSize),
                NationalityFull = StringUtil.BytesToString(data.nationalityFull, data.nationalityFullSize)
            };
            return fixedPersonalData;
        }
    }
}
