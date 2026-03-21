<script>
	const { isOpen } = $props();

	async function addCigarette() {
		try {
			const res = await fetch("http://localhost:5150/api/logs", {
				method: "POST"
			});

			const data = await res.json();
			console.log(data);
			close();
		} catch (error) {
			console.error(error);
		}
	}

	let dialog;

	export function open() {
		dialog.showModal();
	}

	function close() {
		dialog.close();
	}
</script>

<dialog bind:this={dialog}>
	<button onclick={addCigarette}>Yes</button>
	<p>Do you really want to smoke that? {isOpen}</p>
	<button onclick={() => close()}>No</button>
</dialog>

<style>
	dialog {
		z-index: 10000;
	}
	p {
		color: black;
	}
</style>
