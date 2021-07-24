using ParkingLotSystem.Services.Interfaces;
using ParkingLotSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Entities
{
    public class ParkingLot
    {
        private IPrint _print;
        private Dictionary<SlotType, Slot>[] _floorSlots;
        public string _name;
        public ParkingLot(IPrint print)
        {
            _print = print;
        }
        //! Looks too convulated to me
        public void CreateParkingLot(string name, int floorCount, int slotsPerFloorCount)
        {
            _name = name;
            _floorSlots = new Dictionary<SlotType, Slot>[floorCount + 1];

            for (int floorId = 1; floorId <= floorCount; ++floorId)
            {
                _floorSlots[floorId] = new Dictionary<SlotType, Slot>();

                for (int slotId = 1; slotId <= slotsPerFloorCount; ++slotId)
                {
                    switch (slotId)
                    {
                        case 1:
                            if (!_floorSlots[floorId].ContainsKey(SlotType.TRUCK))
                            {
                                _floorSlots[floorId].Add(SlotType.TRUCK, new Slot());
                            }
                            _floorSlots[floorId][SlotType.TRUCK].FreeSlots.Add(slotId);
                            break;
                        case 2:
                        case 3:
                            if (!_floorSlots[floorId].ContainsKey(SlotType.BIKE))
                            {
                                _floorSlots[floorId].Add(SlotType.BIKE, new Slot());
                            }
                            _floorSlots[floorId][SlotType.BIKE].FreeSlots.Add(slotId);
                            break;
                        default:
                            if (!_floorSlots[floorId].ContainsKey(SlotType.CAR))
                            {
                                _floorSlots[floorId].Add(SlotType.CAR, new Slot());
                            }
                            _floorSlots[floorId][SlotType.CAR].FreeSlots.Add(slotId);
                            break;
                    }

                }
            }
            _print.Print($"Created parking lot with {floorCount} floors and {slotsPerFloorCount} slots per floor");

        }
        public FloorSlot AcquireFreeSlot(SlotType slotType)
        {
            for (int floorId = 1; floorId < _floorSlots.Length; ++floorId)
            {
                if (_floorSlots[floorId][slotType].FreeSlots.Count > 0)
                {
                    int slotId = _floorSlots[floorId][slotType].FreeSlots.ElementAt(0);
                    _floorSlots[floorId][slotType].FreeSlots.Remove(slotId);
                    _floorSlots[floorId][slotType].OccupiedSlots.Add(slotId);
                    return new FloorSlot(floorId, slotId);
                }
            }
            return null;
        }
        public Dictionary<int, int> GetFreeSlotsCountPerFloor(SlotType slotType)
        {
            Dictionary<int, int> floorIdFreeSlotCount = new Dictionary<int, int>();
            for (int floorId = 1; floorId < _floorSlots.Length; ++floorId)
            {
                if (!floorIdFreeSlotCount.ContainsKey(floorId))
                {
                    floorIdFreeSlotCount.Add(floorId, 0);
                }
                floorIdFreeSlotCount[floorId] += _floorSlots[floorId][slotType].FreeSlots.Count;
            }
            return floorIdFreeSlotCount;
        }
        public Dictionary<int, List<int>> GetSlotsPerFloor(SlotType slotType, DisplayType displayType)
        {
            Dictionary<int, List<int>> floorIdSlotIds = new Dictionary<int, List<int>>();
            for (int floorId = 1; floorId < _floorSlots.Length; ++floorId)
            {
                SortedSet<int> slots = displayType == DisplayType.free_slots ? _floorSlots[floorId][slotType].FreeSlots :
                                                                               _floorSlots[floorId][slotType].OccupiedSlots;

                floorIdSlotIds.Add(floorId, new List<int>());
                foreach (int slotId in slots)
                {
                    floorIdSlotIds[floorId].Add(slotId);
                }
            }
            return floorIdSlotIds;
        }

        public void ReleaseSlot(SlotType slotType, int floorId, int slotId)
        {
            _floorSlots[floorId][slotType].RemoveOccupiedSlot(slotId);
            _floorSlots[floorId][slotType].AddFreeSlot(slotId);
        }

        public class Slot
        {
            public SortedSet<int> FreeSlots { get; private set; }
            public SortedSet<int> OccupiedSlots { get; private set; }

            public Slot()
            {
                FreeSlots = new SortedSet<int>();
                OccupiedSlots = new SortedSet<int>();
            }
            public void AddFreeSlot(int slotId)
            {
                FreeSlots.Add(slotId);
            }
            public void RemoveFreeSlot(int slotId)
            {
                FreeSlots.Remove(slotId);
            }
            public void AddOccupiedSlot(int slotId)
            {
                OccupiedSlots.Add(slotId);
            }
            public void RemoveOccupiedSlot(int slotId)
            {
                OccupiedSlots.Remove(slotId);
            }
        }

        public class FloorSlot
        {
            public int FloorId { get; private set; }
            public int SlotId { get; private set; }
            public FloorSlot(int floorId, int slotId)
            {
                FloorId = floorId;
                SlotId = slotId;
            }
        }



    }
}





