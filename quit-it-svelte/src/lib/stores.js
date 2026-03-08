import { writable } from 'svelte/store';

// Create a writable store for API response data
export const apiData = writable({
	logs: null,
	loading: false,
	error: null
});

// Helper function to fetch and update the store
export async function fetchApiData(url) {
	apiData.update(() => ({ logs: null, loading: true, error: null }));

	try {
		const res = await fetch(url);
		if (!res.ok) {
			throw new Error(`HTTP error. Status: ${res.status}`);
		}
		const data = await res.json();
		apiData.update(() => ({ logs: data, loading: false, error: null }));
		return data;
	} catch (err) {
		apiData.update(() => ({ logs: null, loading: false, error: err.message }));
		throw err;
	}
}
