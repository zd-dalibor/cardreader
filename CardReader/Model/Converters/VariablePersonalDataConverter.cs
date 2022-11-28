using CardReader.Model.Data;
using CardReader.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model.Converters
{
    public class VariablePersonalDataConverter
    {
        public static VariablePersonalData From(IdReaderLib.EID_VARIABLE_PERSONAL_DATA data)
        {
            var variablePersonalData = new VariablePersonalData
            {
                State = StringUtil.BytesToString(data.state, data.stateSize),
                Community = StringUtil.BytesToString(data.community, data.communitySize),
                Place = StringUtil.BytesToString(data.place, data.placeSize),
                Street = StringUtil.BytesToString(data.street, data.streetSize),
                HouseNumber = StringUtil.BytesToString(data.houseNumber, data.houseNumberSize),
                HouseLetter = StringUtil.BytesToString(data.houseLetter, data.houseLetterSize),
                Entrance = StringUtil.BytesToString(data.entrance, data.entranceSize),
                Floor = StringUtil.BytesToString(data.floor, data.floorSize),
                ApartmentNumber = StringUtil.BytesToString(data.apartmentNumber, data.apartmentNumberSize),
                AddressDate = StringUtil.BytesToString(data.addressDate, data.addressDateSize),
                AddressLabel = StringUtil.BytesToString(data.addressLabel, data.addressLabelSize)
            };
            return variablePersonalData;
        }
    }
}
