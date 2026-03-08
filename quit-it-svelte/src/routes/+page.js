export async function load({ fetch }) {
	const res = await fetch('http://localhost:7070/api/logs');
	const logs = await res.json();
	console.log(logs)
	return { logs };
}
