let leafletMaps = {};
let currentBoundaries = {};

window.initMap = (mapId, latitude, longitude, zoom) => {
    const map = L.map(mapId).setView([latitude, longitude], zoom);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    leafletMaps[mapId] = map;
};

window.drawBoundry = (mapId, coordinates) => {
    const map = leafletMaps[mapId];
    if (!map || !Array.isArray(coordinates))
        return;
    if (currentBoundaries[mapId]) {
        map.removeLayer(currentBoundaries[mapId]);
    }
    const latlngs = coordinates.map(coord => [parseFloat(coord.latitude), parseFloat(coord.longitude)]);
    const polygon = L.polygon(latlngs, {
        color: 'blue',
        fillColor: 'lightblue',
        fillOpacity: 0.7,
    }).addTo(map);

    currentBoundaries[mapId] = polygon;
    map.fitBounds(polygon.getBounds());
    console.log("Drawing boundry with", latlngs.length, "points");
};